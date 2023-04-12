using Autofac;
using VictorKrogh.NET.Data.Database.Dapper.Provider.MySql;
using VictorKrogh.NET.Data.Provider;

namespace VictorKrogh.NET.Data.Extensions.DependencyInjection;

public static class MySqlClientDbProviderContainerBuilderExtensions
{
    public static ContainerBuilder RegisterMySqlClientDbProvider<TProvider>(this ContainerBuilder containerBuilder, MySqlClientDbProviderSettings mySqlClientDbProviderSettings)
        where TProvider : class, IMySqlClientDbProvider
    {
        containerBuilder.RegisterProvider<TProvider>();

        containerBuilder.RegisterMySqlClientDbProviderFactory<TProvider>(mySqlClientDbProviderSettings);
        
        containerBuilder.RegisterRepositories<TProvider>();

        return containerBuilder;
    }

    public static ContainerBuilder RegisterMySqlClientDbProviderFactory<TProvider>(this ContainerBuilder containerBuilder, MySqlClientDbProviderSettings mySqlClientDbProviderSettings)
        where TProvider : class, IMySqlClientDbProvider
    {
        containerBuilder.RegisterType<MySqlClientDbProviderFactory<TProvider>>()
            .UsingConstructor(typeof(MySqlClientDbProviderSettings))
            .WithParameter(TypedParameter.From(mySqlClientDbProviderSettings))
            .As<IProviderFactory<TProvider>>()
            .InstancePerLifetimeScope();

        return containerBuilder;
    }
}
