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
using System.Threading;

namespace NAntGui.Framework
{
    public abstract class BuildRunnerBase
    {
        public event EventHandler<BuildFinishedEventArgs> BuildFinished;

        protected ILogsMessage _logger;
        protected CommandLineOptions _options;
        protected List<IBuildProperty> _properties;
        protected List<IBuildTarget> _targets;
        protected FileInfo _fileInfo;

        private Thread _thread;

        protected BuildRunnerBase(FileInfo fileInfo, ILogsMessage logger, CommandLineOptions options)
        {
            Assert.NotNull(logger, "logger");
            Assert.NotNull(options, "options");
            Assert.NotNull(fileInfo, "fileInfo");

            _fileInfo = fileInfo;
            _logger = logger;
            _options = options;
        }

        public List<IBuildProperty> Properties
        {
            set { _properties = value; }
        }

        public List<IBuildTarget> Targets
        {
            set { _targets = value; }
        }

        protected abstract void DoRun();

        public void Run()
        {
            _thread = new Thread(DoRun);
            _thread.SetApartmentState(ApartmentState.STA);

            BeforeStart();
            _thread.Start();
            AfterStart();
        }

        protected virtual void BeforeStart()
        {

        }

        protected virtual void AfterStart()
        {

        }

        public void Stop()
        {
            if (_thread != null)
            {
                BeforeStop();
                BuildFinished = null;
                _thread.Abort();
                AfterStop();
            }
        }

        protected virtual void BeforeStop()
        {
            
        }

        protected virtual void AfterStop()
        {

        }

        protected void FinishBuild()
        {
            if (BuildFinished != null)
                BuildFinished(this, new BuildFinishedEventArgs());
        }
    }
}