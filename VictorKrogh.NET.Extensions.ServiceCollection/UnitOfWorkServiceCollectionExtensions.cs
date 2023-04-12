using Microsoft.Extensions.DependencyInjection;
using VictorKrogh.NET.Data;
using VictorKrogh.NET.Data.Provider;

namespace VictorKrogh.NET.Extensions.DependencyInjection;

public static class UnitOfWorkServiceCollectionExtensions
{
    public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWorkFactory, UnitOfWorkFactory>();

        services.AddScoped<IProviderFactory>(serviceProvider =>
        {
            var unitOfWorkFactory = serviceProvider.GetRequiredService<IUnitOfWorkFactory>();

            return unitOfWorkFactory.Create();
        });

        services.AddScoped<IUnitOfWork>(serviceProvider =>
        {
            var unitOfWorkFactory = serviceProvider.GetRequiredService<IUnitOfWorkFactory>();

            return unitOfWorkFactory.Create();
        });

        return services;
    }
}