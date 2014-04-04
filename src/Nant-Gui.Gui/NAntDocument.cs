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
using System.Windows.Forms;
using NAntGui.Core;
using NAntGui.Framework;

namespace NAntGui.Gui
{
    /// <summary>
    /// </summary>
    internal class NAntDocument
    {
        private readonly CommandLineOptions _options;
        private readonly ILogsMessage _logger;
        private BuildRunnerBase _buildRunner;

        /// <summary>
        /// Creates new untitled document
        /// </summary>
        internal NAntDocument(ILogsMessage logger, CommandLineOptions options)
        {
            Assert.NotNull(logger, "logger");
            Assert.NotNull(options, "options");

            _options = options;
            _logger = logger;
            Name = "Untitled*";
            Directory = ".\\";
            FullName = Directory + Name;
            Contents = "";
            FileType = FileType.New;

            BuildScript = new BlankBuildScript();
        }

        /// <summary>
        /// Loads an existing project file
        /// </summary>
        internal NAntDocument(string filename, ILogsMessage logger, CommandLineOptions options)
        {
            Assert.NotNull(filename, "filename");
            Assert.NotNull(logger, "logger");
            Assert.NotNull(options, "options");

            _options = options;
            _logger = logger;
            FullName = filename;

            FileInfo fileInfo = new FileInfo(FullName);
            Name = fileInfo.Name;
            Directory = fileInfo.DirectoryName;

            Load();

            BuildScript = ScriptParserFactory.Create(fileInfo);
            _buildRunner = BuildRunnerFactory.Create(fileInfo, logger, _options);
            _buildRunner.Properties = BuildScript.Properties;
        }

        internal void ParseBuildScript()
        {
            BuildScript.Parse();
        }

        internal void Reload()
        {
            if (FileType == FileType.Existing)
            {
                Load();
                ParseBuildFile();
            }
        }

        internal void SaveAs(string filename, string contents)
        {
            Assert.NotNull(filename, "filename");
            Assert.NotNull(contents, "contents");

            FullName = filename;
            Contents = contents;

            File.WriteAllText(FullName, Contents);

            FileInfo fileInfo = new FileInfo(filename);
            Name = fileInfo.Name;
            Directory = fileInfo.DirectoryName;
            LastModified = fileInfo.LastWriteTime;
            FileType = FileType.Existing;

            BuildScript = ScriptParserFactory.Create(fileInfo);
            _buildRunner = BuildRunnerFactory.Create(fileInfo, _logger, _options);

            ParseBuildFile();
        }

        internal void Save(string contents, bool update)
        {
            File.WriteAllText(FullName, contents);
            LastModified = File.GetLastWriteTime(FullName);
            Contents = contents;

            if (update)
                ParseBuildFile();
        }

        private void Load()
        {
            FileType = FileType.Existing;
            Contents = File.ReadAllText(FullName);
            LastModified = File.GetLastWriteTime(FullName);
        }

        internal void Stop()
        {
            if (_buildRunner != null)
                _buildRunner.Stop();
        }

        internal void Run()
        {
            if (_buildRunner != null)
                _buildRunner.Run();
        }

        internal void SetTargets(List<IBuildTarget> targets)
        {
            Assert.NotNull(targets, "targets");
            if (_buildRunner != null)
                _buildRunner.Targets = targets;
        }

        internal void Close()
        {
            if (_buildRunner != null)
                _buildRunner.Stop();
        }

        private void ParseBuildFile()
        {
            // Might want a more specific exception type to be caught here.
            // For example, a NullReferenceException on _buildScript 
            // shouldn't be ignored.
            try
            {
                BuildScript.Parse();
            }
#if DEBUG
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
#else
			catch
			{
				/* ignore */
			}
#endif
        }

        internal event EventHandler<BuildFinishedEventArgs> BuildFinished
        {
            add { _buildRunner.BuildFinished += value; }
            remove { _buildRunner.BuildFinished -= value; }
        }

        #region Properties

        public string Contents { get; set; }

        public FileType FileType { get; set; }

        public string FullName { get; private set; }

        public string Name { get; private set; }

        public string Directory { get; private set; }

        internal IBuildScript BuildScript { get; private set; }

        public DateTime LastModified { get; private set; }

        public DateTime IgnoreModifiedDate { get; set; }

        #endregion
    }
}