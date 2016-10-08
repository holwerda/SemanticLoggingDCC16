using System;
using Microsoft.Diagnostics.Tracing;

namespace DCC16_Demo3
{
    [EventSource(Name = "DCC16-DCC16Demo3-Demo3EventSource")]
    public sealed class Demo3EventSource : EventSource
    {
        private static Lazy<Demo3EventSource> _log = new Lazy<Demo3EventSource>();

        public Demo3EventSource() { }

        public static Demo3EventSource Log
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

        [Event(4, Level = EventLevel.Error, Channel = EventChannel.Admin, Message = "There has been an error retrieving user {0}: {1}")]
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
