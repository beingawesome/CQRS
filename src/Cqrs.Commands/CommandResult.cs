using Cqrs.Versioning;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cqrs.Commands
{
    public class CommandResult
    {
        internal CommandResult(bool success, Commit version, IEnumerable<CommandMessage> errors, IEnumerable<CommandMessage> warnings)
        {
            Version = version;
            Errors = errors?.ToList() ?? Enumerable.Empty<CommandMessage>();
            Warnings = warnings?.ToList() ?? Enumerable.Empty<CommandMessage>();
        }

        public IEnumerable<CommandMessage> Errors { get; }

        public IEnumerable<CommandMessage> Warnings { get; }

        public Commit Version { get; }
    }
}
