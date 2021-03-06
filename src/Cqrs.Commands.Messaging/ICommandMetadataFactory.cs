using Cqrs.Metadata;

namespace Cqrs.Commands.Messaging
{
    public interface ICommandMetadataFactory
    {
        IMetadata Create<TCommand>(TCommand command)
            where TCommand : Command;
    }
}
