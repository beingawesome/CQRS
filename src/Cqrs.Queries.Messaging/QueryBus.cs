using Cqrs.Metadata;
using System.Reflection;
using System.Threading.Tasks;

namespace Cqrs.Queries.Messaging
{
    public class QueryBus
    {
        private static readonly MethodInfo ExecuteAsyncMethod = typeof(IBusAdapter).GetMethod(nameof(IBusAdapter.ExecuteAsync));
        private static readonly MethodInfo CreateMethod = typeof(IQueryMetadataFactory).GetMethod(nameof(IQueryMetadataFactory.Create));

        private readonly IBusAdapter _bus;
        private readonly IQueryMetadataFactory _metadata;

        internal QueryBus(IBusAdapter bus, IQueryMetadataFactory metadata)
        {
            _bus = bus;
            _metadata = metadata;
        }

        public Task<TResult> ExecuteAsync<TResult>(Query<TResult> query)
        {
            var create = CreateMethod.MakeGenericMethod(query.GetType(), typeof(TResult));
            var execute = ExecuteAsyncMethod.MakeGenericMethod(query.GetType(), typeof(TResult));

            var metadata = (IMetadata)create.Invoke(_metadata, new[] { query });

            return (Task<TResult>)execute.Invoke(_bus, new object[] { query, metadata });
        }
    }
}
