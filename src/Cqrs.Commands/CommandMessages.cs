using System;
using System.Collections;
using System.Collections.Generic;

namespace Cqrs.Commands
{
    public class CommandMessages : IEnumerable<CommandMessage>
    {
        private readonly List<CommandMessage> _inner = new List<CommandMessage>();
        
        internal CommandMessages() { }

        public void Add(string message) => Add(String.Empty, message);

        public void Add(string key, string message) => Add(new CommandMessage(key, message));

        public void Add(Exception ex) => Add(ex.Message, ex);

        public void Add(string message, Exception ex) => Add(new CommandMessage(String.Empty, message, ex));

        public void Add(CommandMessage message) => _inner.Add(message);

        public IEnumerator<CommandMessage> GetEnumerator() => _inner.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
