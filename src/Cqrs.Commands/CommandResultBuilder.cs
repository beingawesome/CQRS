using Cqrs.Versioning;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cqrs.Commands
{
    public class CommandResultBuilder
    {
        private readonly bool _warningsAsErrorss;

        public CommandResultBuilder() : this(false) { }

        public CommandResultBuilder(bool warningsAsErrorss)
        {
            _warningsAsErrorss = warningsAsErrorss;
        }

        public bool HasError => Errors.Any() || (_warningsAsErrorss && Warnings.Any());

        public CommandMessages Errors { get; } = new CommandMessages();
        public CommandMessages Warnings { get; } = new CommandMessages();

        public CommandResult Build()
        {
            return Build(Commit.Any);
        }

        public CommandResult Build(Commit version)
        {
            return new CommandResult(HasError, version, Errors, Warnings);
        }

        public static CommandResult Success()
        {
            return Success(Commit.Any);
        }

        public static CommandResult Success(Commit version)
        {
            return new CommandResult(true, version, null, null);
        }
    }
}
