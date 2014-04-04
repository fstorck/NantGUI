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
using System.Collections.Generic;
using System.IO;
using Microsoft.Build.BuildEngine;
using NAntGui.Framework;
using BuildProperty=Microsoft.Build.BuildEngine.BuildProperty;


namespace NAntGui.MSBuild
{
    public class MSBuildScript : BuildScript
    {
        private List<string> _defaultTargets;
        private List<string> _initialTargets;

        public MSBuildScript(FileInfo file) : base(file)
        {
            Name = file.Name;
        }

        public override void Parse()
        {
            Project project = CreateProject();

            Targets.Clear();
            Properties.Clear();

            ParseDefaultTargets(project);
            ParseInitialTargets(project);
            ParseTargets(project);
            ParseProperties(project);
        }

        private Project CreateProject()
        {
            try
            {
                Project project = new Project(MSBuildRunner.Engine);
                project.Load(_file.FullName);
                return project;
            }
            catch (ArgumentException)
            {
                return null;
            }
            catch (Exception error)
            {
                throw new BuildFileLoadException("Error parsing MSBuild project", error);
            }
        }

        private void ParseDefaultTargets(Project project)
        {
            _defaultTargets = new List<string>(project.DefaultTargets.Replace(" ", "").Split(';'));
        }

        private void ParseInitialTargets(Project project)
        {
            _initialTargets = new List<string>(project.InitialTargets.Replace(" ", "").Split(';'));
        }

        private void ParseTargets(Project project)
        {
            foreach (Target mstarget in project.Targets)
            {
                if (!mstarget.IsImported || _defaultTargets.Contains(mstarget.Name))
                {
                    MSBuildTarget target = new MSBuildTarget(mstarget.Name);
                    target.Condition = mstarget.Condition;
                    target.Depends = mstarget.DependsOnTargets.Replace(" ", "").Split(';');

                    if (_defaultTargets.Contains(target.Name))
                        target.Default = true;

                    if (_initialTargets.Contains(target.Name))
                        target.Initial = true;

                    Targets.Add(target);
                }
            }

            //Targets.Sort();
        }

        private void ParseProperties(Project project)
        {
            foreach (BuildPropertyGroup group in project.PropertyGroups)
            {
                foreach (BuildProperty msproperty in group)
                {
                    // TODO: Should allow the user to toggle shwoing imported properties
                    if (!msproperty.Name.StartsWith("_") && !msproperty.IsImported)
                    {
                        // TODO: Should allow the user to toggle using the FinalValue on and off, 
                        // because sometimes they may want to change the actual value, and sometimes 
                        // the expanded value
                        MSBuildProperty property = new MSBuildProperty(msproperty.Name, msproperty.FinalValue,
                                                                       group.Condition, msproperty.Condition);
                        Properties.Add(property);
                    }
                }
            }
        }
    }
}