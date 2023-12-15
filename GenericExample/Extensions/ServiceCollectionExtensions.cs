using GenericExample.Services.Documents;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace GenericExample.Extensions
{
    internal static class ServiceCollectionExtensions
    {
        private static IServiceCollection AddGenericService(this IServiceCollection services)
        {
            return services.Scan(scan => scan.FromAssemblies(typeof(Programm).Assembly, typeof(IDocumentProcessor<,>).Assembly)
                .AddClasses(value => value.AssignableToAny(
                    typeof(IDocumentProcessor<,>),
                    typeof(IDocumentPositionProcessor<,>),
                    typeof(IDocumentBuilder<,>),
                    typeof(IDocumentPositionBuilder<,>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime());
        }
    }
}
