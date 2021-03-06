using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Cqrs.Queries.Messaging
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInMemoryQueryMessaging(this IServiceCollection services)
        {
            services.AddQueryBus();

            services.TryAddSingleton<QueryHandlers>();
            services.TryAddSingleton<IBusAdapter, InMemoryBusAdapter>();

            return services;
        }
    }
}
