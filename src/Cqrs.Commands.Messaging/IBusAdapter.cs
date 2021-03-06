using Cqrs.Metadata;
using Cqrs.Versioning;
using System.Threading.Tasks;

namespace Cqrs.Commands.Messaging
{
    public interface IBusAdapter
    {
        Task<CommandResult> SendAsync<TCommand>(TCommand command, IReadOnlyMetadata metadata)
            where TCommand : Command;
    }
}
