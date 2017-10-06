using Cqrs.Metadata;
using Cqrs.Versioning;
using System;
using System.Threading.Tasks;

namespace Cqrs.Commands.Handlers
{
    public interface ICommandHandler<TCommand>
        where TCommand : Command
    {
        Task<CommandResult> HandleAsync(TCommand command, IReadOnlyMetadata metadata);
    }
}
