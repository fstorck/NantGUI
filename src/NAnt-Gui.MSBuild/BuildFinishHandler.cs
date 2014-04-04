using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

namespace NAntGui.MSBuild
{
    class BuildFinishHandler : Logger
    {
        private readonly BuildFinishedEventHandler _handler;

        internal BuildFinishHandler(BuildFinishedEventHandler handler)
        {
            _handler = handler;
        }

        public override void Initialize(IEventSource eventSource)
        {
            eventSource.BuildFinished += _handler;
        }
    }
}
