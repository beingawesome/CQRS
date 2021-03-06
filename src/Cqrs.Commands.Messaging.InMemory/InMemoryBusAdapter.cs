using Cqrs.Metadata;
using Cqrs.Versioning;
using System.Threading.Tasks;

namespace Cqrs.Commands.Messaging.InMemory
{
    internal class InMemoryBusAdapter : IBusAdapter
    {
        private readonly CommandHandlers _handlers;

        public InMemoryBusAdapter(CommandHandlers handlers)
        {
            _handlers = handlers;
        }

        public Task<CommandResult> SendAsync<TCommand>(TCommand command, IReadOnlyMetadata metadata)
            where TCommand : Command
        {
            var handler = _handlers.Build<TCommand>();

            return handler.HandleAsync(command, metadata);
        }
    }
}
