using System;
using System.Diagnostics.Tracing;
using Microsoft.Practices.EnterpriseLibrary.SemanticLogging;
using Microsoft.Practices.EnterpriseLibrary.SemanticLogging.Formatters;

namespace DCC16_Demo4
{
    public class InProcSlabManagement
    {
        private static ObservableEventListener listener = new ObservableEventListener();

        private static EventSource eventSource { get; set; }

        public static void StartInProcTracing(EventSource source)
        {
            if (eventSource != null)
            {
                throw new InvalidOperationException("started in proc tracing multiple times");
            }

            eventSource = source;

            var formatter = new JsonEventTextFormatter(EventTextFormatting.Indented);

            listener.EnableEvents(source, EventLevel.LogAlways, Keywords.All);
            listener.LogToConsole(formatter);
        }

        public static void StopInProcTracing()
        {
            if (eventSource == null) return;
            listener.DisableEvents(eventSource);
            listener.Dispose();
            eventSource.Dispose();
        }
    }
}
