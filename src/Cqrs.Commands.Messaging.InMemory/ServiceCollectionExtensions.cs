using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Cqrs.Commands.Messaging.InMemory
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInMemoryCommandMessaging(this IServiceCollection services)
        {
            services.AddCommandBus();

            services.TryAddSingleton<CommandHandlers>();
            services.TryAddSingleton<IBusAdapter, InMemoryBusAdapter>();

            return services;
        }
    }
}
