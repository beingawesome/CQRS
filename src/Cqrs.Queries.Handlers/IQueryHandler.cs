using Cqrs.Metadata;
using System.Threading.Tasks;

namespace Cqrs.Queries.Handlers
{
    public interface IQueryHandler<TQuery, TResult>
        where TQuery : Query<TResult>
    {
        Task<TResult> ExecuteAsync(TQuery query, IReadOnlyMetadata metadata);
    }
}
