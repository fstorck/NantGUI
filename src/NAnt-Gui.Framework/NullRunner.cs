using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace NAntGui.Framework
{
    public class NullRunner : BuildRunnerBase
    {
        public NullRunner(FileInfo fileInfo, ILogsMessage logger, CommandLineOptions options) :
            base(fileInfo, logger, options)
        {
            
        }
    
        protected override void DoRun()
        {
        }            
    }
}
