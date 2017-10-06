using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Cqrs.Commands.Handlers.DependencyInjection
{

    public static class ServiceCollectionExtensions
    {
        private static readonly Type HandlerType = typeof(ICommandHandler<>);

        public static IServiceCollection AddCommandHandlersFromAssembly<T>(this IServiceCollection services)
        {
            // TODO: Add marker to service collection to prevent duplicate calls

            return services.AddCommandHandlersFromAssembly(typeof(T).Assembly);
        }

        private static IServiceCollection AddCommandHandlersFromAssembly(this IServiceCollection services, Assembly assembly)
        {
            foreach (var mapping in GetHandlerMappings(assembly))
            {
                services.AddTransient(mapping.Key, mapping.Value);
            }

            return services;
        }

        private static IDictionary<Type, Type> GetHandlerMappings(Assembly asm)
        {
            return (from type in asm.DefinedTypes
                    where !type.IsAbstract && !type.IsInterface
                    from i in type.ImplementedInterfaces
                    let detail = i.GetTypeInfo()
                    where detail.IsGenericType
                    let def = detail.GetGenericTypeDefinition()
                    where def == HandlerType
                    select new { i, Impl = type.AsType() }).ToDictionary(x => x.i, x => x.Impl);
        }
    }
}
