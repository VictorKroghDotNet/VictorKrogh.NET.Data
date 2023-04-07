using Microsoft.Extensions.DependencyInjection;
using VictorKrogh.NET.Data.Database.Dapper.Provider.MySql;
using VictorKrogh.NET.Data.Provider;

namespace VictorKrogh.NET.Extensions.DependencyInjection;

public static class MySqlClientDbProviderServiceCollectionExtensions
{
    public static IServiceCollection AddMySqlClientDbProvder<TProvider>(this IServiceCollection services)
        where TProvider : class, IMySqlClientDbProvider
    {
        var providerType = typeof(TProvider);

        var providerInterfaceType = providerType.GetInterface($"I{providerType}");

        if (providerInterfaceType == null)
        {
            throw new Exception("?!");
        }

        services.AddScoped(providerInterfaceType, serviceProvider =>
        {
            var providerFactory = serviceProvider.GetRequiredService<IProviderFactory>();

            return providerFactory.CreateProvider<TProvider>();
        });

        return services;
    }

    public static IServiceCollection AddMySqlClientDbProviderFactory<TProvider>(this IServiceCollection services, MySqlClientDbProviderSettings mySqlClientDbProviderSettings)
        where TProvider : class, IMySqlClientDbProvider
    {
        services.AddScoped<IProviderFactory<TProvider>, MySqlClientDbProviderFactory<TProvider>>(serviceProvider =>
        {
            return new MySqlClientDbProviderFactory<TProvider>(mySqlClientDbProviderSettings);
        });

        return services;
    }
}
