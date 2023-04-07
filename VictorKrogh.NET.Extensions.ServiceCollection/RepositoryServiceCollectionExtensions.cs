using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using VictorKrogh.NET.Data.Provider;
using VictorKrogh.NET.Data.Repository;

namespace VictorKrogh.NET.Extensions.DependencyInjection;

public static class RepositoryServiceCollectionExtensions
{
    public static IServiceCollection AddRepositories<TProvider>(this IServiceCollection services)
        where TProvider : class, IProvider
    {
        return services.AddRepositories(typeof(TProvider).Assembly);
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services, Assembly assembly)
    {
        var repositoryTypes = assembly.DefinedTypes.Where(t => t.IsAssignableTo(typeof(IRepository)));

        foreach(var repositoryType in repositoryTypes)
        {
            var interfaceTypes = repositoryType.GetInterfaces();

            var interfaceType = interfaceTypes.FirstOrDefault(i => i.IsInterface && (i.Name?.Equals($"I{repositoryType.Name}") ?? false));

            if(interfaceType == default)
            {
                continue;
            }

            services.AddTransient(interfaceType, repositoryType);
        }

        return services;
    }
}
