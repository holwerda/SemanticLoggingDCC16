using System;
using System.Diagnostics.Tracing;

namespace DCC16_Demo2
{
    [EventSource(Name = "DCC16-DCC16Demo2-Demo2EventSource")]
    public sealed class Demo2EventSource : EventSource
    {
        private static Lazy<Demo2EventSource> _log = new Lazy<Demo2EventSource>();

        public Demo2EventSource() { }

        public static Demo2EventSource Log
        {
            get { return _log.Value; }
        }

        [Event(1, Level = EventLevel.LogAlways, Keywords = Keywords.General, Opcode = OpCodes.DCC, Task = Tasks.ATask)]
        public void Event1WasSelected(string message)
        {
            WriteEvent(1, message);
        }

        [Event(2, Level = EventLevel.Informational, Message = "The data by id {0} has been retrieved")]
        public void Event2GetById(int id)
        {
            WriteEvent(2, id);
        }

        [Event(3, Level = EventLevel.Informational, Message = "Superpowers activated for user {0} with a first name of {1} and last name of {2}")]
        public void Event3SuperPowersActivated(int id, string firstName, string lastName)
        {
            WriteEvent(3, id, firstName, lastName);
        }

        [Event(4, Level = EventLevel.Error)]
        public void Event4Error(int id, string message)
        {
            WriteEvent(4, id, message);
        }

        [Event(5, Level = EventLevel.Informational)]
        public void ApplicationStart()
        {
            WriteEvent(5);

        }

        [Event(6, Level = EventLevel.Informational)]
        public void ApplicationExit()
        {
            WriteEvent(6);

        }

        public class Keywords
        {
            public const EventKeywords General = (EventKeywords)0x0001;
            public const EventKeywords Assert = (EventKeywords)0x0002;
            public const EventKeywords Data = (EventKeywords)0x0004;
        }

        public class OpCodes
        {
            public const EventOpcode DCC = (EventOpcode)0x0001;
        }
        public class Tasks
        {
            public const EventTask ATask = (EventTask)0x0001;
            public const EventTask AnotherTask = (EventTask)0x0002;
        }

    }
}
