using Cqrs.Metadata;
using System.Threading.Tasks;

namespace Cqrs.Queries.Messaging
{
    public interface IBusAdapter
    {
        Task<TResult> ExecuteAsync<TQuery, TResult>(TQuery query, IReadOnlyMetadata metadata)
               where TQuery : Query<TResult>;
    }
}
