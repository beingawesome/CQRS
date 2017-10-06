using Cqrs.Metadata;
using System.Threading.Tasks;

namespace Cqrs.Queries.Messaging
{
    internal class InMemoryBusAdapter : IBusAdapter
    {
        private readonly QueryHandlers _handlers;

        public InMemoryBusAdapter(QueryHandlers handlers)
        {
            _handlers = handlers;
        }

        public Task<TResult> ExecuteAsync<TQuery, TResult>(TQuery query, IReadOnlyMetadata metadata) where TQuery : Query<TResult>
        {
            var handler = _handlers.Build<TQuery, TResult>();
            
            return handler.ExecuteAsync(query, metadata);
        }
    }
}
