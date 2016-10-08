using System;
using System.Diagnostics.Tracing;

namespace DCC16_Demo4
{
    [EventSource(Name = "DCC16-DCC16Demo4-Demo4EventSource")]
    public sealed class Demo4EventSource : EventSource
    {
        private static Lazy<Demo4EventSource> _log = new Lazy<Demo4EventSource>();

        public Demo4EventSource() { }

        public static Demo4EventSource Log
        {
            get { return _log.Value; }
        }

        [Event(1, Level = EventLevel.LogAlways)]
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

        [Event(4, Level = EventLevel.Error, Message = "There has been an error: {0}")]
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

    }
}
