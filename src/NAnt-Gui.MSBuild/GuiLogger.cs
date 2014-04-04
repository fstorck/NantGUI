using System;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using NAntGui.Framework;

namespace NAntGui.MSBuild
{
    class GuiLogger : Logger
    {
        private readonly ILogsMessage _messageLogger;

        public GuiLogger(ILogsMessage messageLogger)
        {
            _messageLogger = messageLogger;
        }

        public override void Initialize(IEventSource eventSource)
        {
            eventSource.MessageRaised += EventSourceMessageRaised;
            eventSource.WarningRaised += EventSourceWarningRaised;
            eventSource.ErrorRaised += EventSourceErrorRaised;
        }

        private void EventSourceErrorRaised(object sender, BuildErrorEventArgs e)
        {
            // BuildErrorEventArgs adds LineNumber, ColumnNumber, File, amongst other parameters
            string line = String.Format("ERROR {0}({1},{2}): ", e.File, e.LineNumber, e.ColumnNumber);
            WriteMessage(line, e);
        }

        private void EventSourceWarningRaised(object sender, BuildWarningEventArgs e)
        {
            // BuildWarningEventArgs adds LineNumber, ColumnNumber, File, amongst other parameters
            string line = String.Format("Warning {0}({1},{2}): ", e.File, e.LineNumber, e.ColumnNumber);
            WriteMessage(line, e);
        }

        private void EventSourceMessageRaised(object sender, BuildMessageEventArgs e)
        {
            // BuildMessageEventArgs adds Importance to BuildEventArgs
            // Let's take account of the verbosity setting we've been passed in deciding whether to log the message
            if ((e.Importance == MessageImportance.High && IsVerbosityAtLeast(LoggerVerbosity.Minimal))
                || (e.Importance == MessageImportance.Normal && IsVerbosityAtLeast(LoggerVerbosity.Normal))
                || (e.Importance == MessageImportance.Low && IsVerbosityAtLeast(LoggerVerbosity.Detailed))
                )
            {
                WriteMessage(string.Empty, e);
            }
        }

        private void WriteMessage(string line, BuildEventArgs e)
        {
            _messageLogger.LogMessage(line + e.Message);
        }
    }
}
