#region Copyleft and Copyright

// NAnt-Gui - Gui frontend to the NAnt .NET build tool
// Copyright (C) 2004-2007 Colin Svingen
//
// This program is free software; you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
//
// Colin Svingen (swoogan@gmail.com)

#endregion

using System;
using System.IO;
using System.Xml;
using NAnt.Core;
using NAnt.Core.Tasks;
using NAnt.Win32.Tasks;
using NAntGui.Framework;

namespace NAntGui.NAnt
{
    /// <summary>
    /// Contains the logic for parsing the build file.
    /// TODO: Convert from XmlDocument to XmlReader.  Create to get line numbers for later use.
    /// </summary>
    public class NAntBuildScript : BuildScript
    {
        private string _baseDir;
        private string _defaultTargetName;

        /// <summary>
        /// Create a new project parser.
        /// </summary>
        public NAntBuildScript(FileInfo file)
            : base(file)
        {
            
        }

        public override void Parse()
        {
            Project project = CreateProject();
            XmlDocument doc = project.Document;

            Targets.Clear();
            Properties.Clear();
            Description = string.Empty;

            Name = project.ProjectName != String.Empty ? project.ProjectName : _file.Name;
            _defaultTargetName = project.DefaultTargetName;

            ParseDescription(doc);
            ParseBaseDir(project);
            ParseTargets(doc);
            ParseProperties(project, doc);
            ParseNonPropertyProperties(project, doc);
            FollowIncludes(project, doc);
        }

        private Project CreateProject()
        {
            try
            {
                return new Project(_file.FullName, Level.Info, 0);
            }
            //catch (ArgumentException)
            //{
            //    return null;
            //}
            catch (Exception error)
            {
                throw new BuildFileLoadException("Error parsing NAnt project", error);
            }
        }

        private void ParseDescription(XmlDocument doc)
        {
            foreach (XmlElement element in doc.GetElementsByTagName("description"))
            {
                Description += element.InnerText + " ";
            }
        }

        private void ParseBaseDir(Project project)
        {
            _baseDir = project.BaseDirectory;
            NAntProperty property = new NAntProperty("BaseDir", _baseDir, "Project", false);
            Properties.Add(property);
        }

        private void ParseTargets(XmlDocument doc)
        {
            foreach (XmlElement element in doc.GetElementsByTagName("target"))
            {
                NAntTarget nantTarget = new NAntTarget();
                nantTarget.ParseAttributes(element);

                if (nantTarget.Name == _defaultTargetName) 
                    nantTarget.Default = true;

                Targets.Add(nantTarget);
            }

            Targets.Sort();
        }

        private void FollowIncludes(Project project, XmlDocument doc)
        {
            foreach (XmlElement element in doc.GetElementsByTagName("include"))
            {
                string buildFile = element.GetAttribute("buildfile");
                string filename = project.ExpandProperties(buildFile, new Location("Buildfile"));

                ParseIncludeFile(project, filename);
            }
        }

        private void ParseIncludeFile(Project project, string filename)
        {
            string fullName = Path.Combine(_baseDir, filename);

            if (File.Exists(fullName))
            {
                try
                {
                    XmlDocument document = new XmlDocument();
                    document.Load(fullName);
                    ParseTargets(document);
                    ParseProperties(project, document);
                    ParseNonPropertyProperties(project, document);
                }
                catch (Exception)
                {
                    /* ignore errors */
                }
            }
        }

        private void ParseProperties(Project project, XmlDocument doc)
        {
            foreach (XmlElement element in doc.GetElementsByTagName("property"))
            {
                NAntProperty property = new NAntProperty(element);

                if (project != null)
                {
                    TryExpandingProperty(project, property);

                    if (!project.Properties.Contains(property.Name))
                    {
                        project.Properties.AddReadOnly(
                            property.Name, property.ExpandedValue);

                        Properties.Add(property);
                    }
                }
                else
                {
                    Properties.Add(property);
                }
            }
        }

        private static void TryExpandingProperty(Project project, IBuildProperty property)
        {
            try
            {
                property.DefaultExpandedValue =
                    property.ExpandedValue =
                    project.ExpandProperties(property.Value, new Location("Buildfile"));
            }
            catch (BuildException)
            {
                // TODO: Do something with the error message
            }
        }

        private void ParseNonPropertyProperties(Project project, XmlDocument doc)
        {
            ParseTstamps(project, doc);
            AddReadRegistrys(project, doc);
            //AddRegex(project);
            ParseLoadfiles(project, doc);
        }

        private void ParseTstamps(Project project, XmlDocument doc)
        {
            foreach (XmlElement element in doc.GetElementsByTagName("tstamp"))
            {
                if (TypeFactory.TaskBuilders.Contains(element.Name))
                {
                    TStampTask task = (TStampTask) project.CreateTask(element);
                    task.Initialize(element);

                    try
                    {
                        task.Execute();
                        NAntProperty property = new NAntProperty(
                            task.Property, task.Properties[task.Property],
                            element.ParentNode.Attributes["name"].Value,
                            true);

                        property.ExpandedValue = property.Value;
                        Properties.Add(property);
                    }
                    catch (BuildException)
                    {
                        // TODO: Do something with the error message
                    }
                }
            }
        }

        private void ParseLoadfiles(Project project, XmlDocument doc)
        {
            foreach (XmlElement element in doc.GetElementsByTagName("loadfile"))
            {
                if (TypeFactory.TaskBuilders.Contains(element.Name))
                {
                    LoadFileTask task = (LoadFileTask) project.CreateTask(element);
                    task.Initialize(element);

                    try
                    {
                        task.Execute();
                        NAntProperty property = new NAntProperty(
                            task.Property, task.Properties[task.Property],
                            element.ParentNode.Attributes["name"].Value,
                            true);

                        property.ExpandedValue = property.Value;
                        Properties.Add(property);
                    }
                    catch (BuildException)
                    {
                        // TODO: Do something with the error message
                    }
                }
            }
        }

        private void AddReadRegistrys(Project project, XmlDocument doc)
        {
            foreach (XmlElement element in doc.GetElementsByTagName("readregistry"))
            {
                if (TypeFactory.TaskBuilders.Contains(element.Name))
                {
                    ReadRegistryTask task = (ReadRegistryTask) project.CreateTask(element);
                    task.Initialize(element);

                    if (task.PropertyName != null)
                    {
                        task.Execute();

                        object val = task.Properties[task.PropertyName];
                        string value = val == null ? "" : val.ToString();

                        NAntProperty property = new NAntProperty(
                            task.PropertyName, value,
                            element.ParentNode.Attributes["name"].Value, false);

                        property.ExpandedValue = property.Value;
                        Properties.Add(property);
                    }
                }
            }
        }

        /*
		/// <summary>
		/// Not in use right now because it opens a can of worms.
		/// The only way to know what value the input attribute has 
		/// is to run the program.  
		/// </summary>
		/// <param name="project"></param>
		private void AddRegex(Project project)
		{
			foreach (XmlElement element in project.Document.GetElementsByTagName("regex"))
			{
				if (TypeFactory.TaskBuilders.Contains(element.Name))
				{
					ReadRegistryTask task = (ReadRegistryTask) project.CreateTask(element);
					if (task != null && task.PropertyName != null)
					{
						task.Execute();

						NAntProperty nAntProperty = new NAntProperty(
							task.PropertyName, task.Properties[task.PropertyName], 
							element.ParentNode.Attributes["name"].Value, false);

						nAntProperty.ExpandedValue = nAntProperty.Value;
						_properties.Add(nAntProperty);
					}
				}
			}
		}
		*/
    }
}