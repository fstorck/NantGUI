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
using Microsoft.Win32;
using NAntGui.Framework;
using BuildFinishedEventArgs=Microsoft.Build.Framework.BuildFinishedEventArgs;

namespace NAntGui.MSBuild
{
    public class MSBuildRunner : BuildRunnerBase
    {
        private const string MSBUILD_TOOLSPATH = @"SOFTWARE\Microsoft\MSBuild\ToolsVersions\2.0";
        private static readonly Engine _engine = new Engine();

        public MSBuildRunner(FileInfo fileInfo, ILogsMessage logger, CommandLineOptions options) :
            base(fileInfo, logger, options)
        {
            RegistryKey key = Registry.LocalMachine.OpenSubKey(MSBUILD_TOOLSPATH, false);
            if (key != null)
            {
                Engine.BinPath = key.GetValue("MSBuildToolsPath").ToString();
                key.Close();
            }

            _engine.RegisterLogger(new GuiLogger(_logger));
            _engine.RegisterLogger(new BuildFinishHandler(Build_Finished));
        }

        public static Engine Engine
        {
            get { return _engine; }
        }

        protected override void DoRun()
        {
            Environment.CurrentDirectory = _fileInfo.DirectoryName;
            
            List<string> targets = _targets.ConvertAll(prop => prop.Name);

            _engine.BuildProjectFile(_fileInfo.FullName, targets.ToArray());
            //SetTargetFramework();
        }

/*
        private BuildPropertyGroup GenerateProperties()
        {
            BuildPropertyGroup group = new BuildPropertyGroup();
            foreach (IBuildProperty property in _properties.Values)
            {
                group.AddNewProperty()
                
            }

            return group;
        }
*/

        private void Build_Finished(object sender, BuildFinishedEventArgs e)
        {
            FinishBuild();
        }
    }
}