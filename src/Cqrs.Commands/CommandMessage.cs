using System;
using System.Collections.Generic;
using System.Text;

namespace Cqrs.Commands
{
    public class CommandMessage
    {
        internal CommandMessage(string key, string message)
        {
            Key = key;
            Message = message;
        }

        internal CommandMessage(string key, string message, Exception exception)
            : this(key, message)
        {
            Exception = exception;
        }

        public string Key { get; }
        public string Message { get; }
        public Exception Exception { get; }
    }

}
