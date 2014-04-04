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
using System.Text.RegularExpressions;
using NAnt.Core;
using NAnt.Core.Util;
using NAntGui.Framework;
using CmdOptions = NAntGui.Framework.CommandLineOptions;

namespace NAntGui.NAnt
{
    public class NAntBuildRunner : BuildRunnerBase
    {
        private Project _project;

        public NAntBuildRunner(FileInfo fileInfo, ILogsMessage logger, CmdOptions options) :
            base(fileInfo, logger, options)
        {
            
        }

/*
		private static string GetErrorMessage(Exception error)
		{
			string message = "";
#if DEBUG
			message += error.GetType().ToString()
				+ Environment.NewLine + error.StackTrace;
#endif

			if (error.InnerException != null && error.InnerException.Message != null)
			{
				message += error.Message + Environment.NewLine + error.InnerException.Message;
			}
			else
			{
				message += error.Message;
			}

			return message;
		}
*/

        protected override void BeforeStop()
        {
            // project can be null if an exception was thrown when it's created in DoRun
            if (_project != null)
                _project.DetachBuildListeners();
        }

        protected override void DoRun()
        {
            try
            {
                Environment.CurrentDirectory = _fileInfo.DirectoryName;

                _project = new Project(_fileInfo.FullName, GetThreshold(), 0);
                _project.BuildFinished += Build_Finished;

                SetTargetFramework();
                AddBuildListeners();
                AddProperties();
                AddTargets();

                _project.Run();
            }
            catch (ArgumentException error)
            {
                _logger.LogMessage(error.Message);
                FinishBuild();
            }
            catch (BuildException error)
            {
                _logger.LogMessage(error.Message);
                FinishBuild();
            }
        }

        private Level GetThreshold()
        {
            Level projectThreshold = Level.Info;
            // determine the project message threshold
            if (_options.Debug)
            {
                projectThreshold = Level.Debug;
            }
            else if (_options.Verbose)
            {
                projectThreshold = Level.Verbose;
            }
            else if (_options.Quiet)
            {
                projectThreshold = Level.Warning;
            }
            return projectThreshold;
        }

        private void AddProperties()
        {
            foreach (IBuildProperty property in _properties)
            {
                if (property.Category == "Project" && property.Name == "BaseDir")
                {
                    _project.BaseDirectory = property.Value;
                }
                else //if (property.Category == "Global" || ValidTarget(property.Category))
                {
                    LoadNonProjectProperty(property);
                }
            }
        }

        private void LoadNonProjectProperty(IBuildProperty property)
        {
            if (!property.ReadOnly &&
                property.ExpandedValue != property.DefaultExpandedValue)
            {
                if (IsNotExpanded(property.ExpandedValue))
                {
                    TryChangingExpandedValue(property);
                }

                _project.Properties.AddReadOnly(property.Name, property.ExpandedValue);
            }
        }

        private static bool IsNotExpanded(string value)
        {
            Regex unexpandedValue = new Regex(@"\$\{[^\}]+\}");
            return unexpandedValue.IsMatch(value);
        }

        private void TryChangingExpandedValue(IBuildProperty property)
        {
            try
            {
                property.ExpandedValue = _project.ExpandProperties(property.ExpandedValue,
                                                                   new Location(_fileInfo.FullName));
            }
            catch (BuildException)
            {
                /* ignore */
            }
        }

        private void AddTargets()
        {
            foreach (IBuildTarget target in _targets)
            {
                _project.BuildTargets.Add(target.Name);
            }
        }

        /// <summary>
        /// Add the listeners specified in the command line arguments,
        /// along with the default listener, to the specified project.
        /// </summary>
        private void AddBuildListeners()
        {
            Assert.NotNull(_project, "project");

            // Create new logger
            IBuildLogger buildLogger = new GuiLogger(_logger);

            // set threshold of build logger equal to threshold of project
            buildLogger.Threshold = _project.Threshold;

            // add build logger to listeners collection
            BuildListenerCollection listeners = new BuildListenerCollection();
            listeners.Add(buildLogger);

            // attach listeners to project
            _project.AttachBuildListeners(listeners);
        }

        private void SetTargetFramework()
        {
            if (_options.TargetFramework != null)
            {
                if (_project.Frameworks.Count == 0)
                {
                    const string message = "There are no supported frameworks available on your system.";
                    throw new ApplicationException(message);
                }

                FrameworkInfo frameworkInfo = _project.Frameworks[_options.TargetFramework];

                if (frameworkInfo != null)
                {
                    _project.TargetFramework = frameworkInfo;
                }
                else
                {
                    const string format = "Invalid framework '{0}' specified.";
                    string message = string.Format(format, _options.TargetFramework);
                    throw new CommandLineArgumentException(message);
                }
            }
        }

        private void Build_Finished(object sender, BuildEventArgs e)
        {
            FinishBuild();
        }
    }
}