using Microsoft.Extensions.DependencyInjection;
using VictorKrogh.NET.Data.Database.Dapper.Provider.MySql;
using VictorKrogh.NET.Data.Provider;

namespace VictorKrogh.NET.Extensions.DependencyInjection;

public static class MySqlClientDbProviderServiceCollectionExtensions
{
    public static IServiceCollection AddMySqlClientProviderFactory<TProvider>(this IServiceCollection services, MySqlClientDbProviderSettings mySqlClientDbProviderSettings)
        where TProvider : class, IMySqlClientDbProvider
    {
        services.AddScoped<IProviderFactory<TProvider>, MySqlClientDbProviderFactory<TProvider>>(serviceProvider =>
        {
            return new MySqlClientDbProviderFactory<TProvider>(mySqlClientDbProviderSettings);
        });

        return services;
    }
}
