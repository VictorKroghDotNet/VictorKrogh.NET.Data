using System.Data;
using System.Reflection;
using VictorKrogh.NET.Data.Provider;

namespace VictorKrogh.NET.Data.Database.Dapper.Provider.MySql;

public sealed class MySqlClientDbProviderFactory<TProvider> : IProviderFactory<TProvider>
    where TProvider : IMySqlClientDbProvider
{
    public MySqlClientDbProviderFactory(MySqlClientDbProviderSettings mySqlClientDbProviderSettings)
    {
        MySqlClientDbProviderSettings = mySqlClientDbProviderSettings;
    }

    private MySqlClientDbProviderSettings MySqlClientDbProviderSettings { get; }

    public TProvider CreateProvider(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
    {
        var type = typeof(TProvider);

        var ctor = type.GetConstructor(BindingFlags.Instance | BindingFlags.Public, null, new[] { typeof(IsolationLevel), typeof(MySqlClientDbProviderSettings) }, null);
        if (ctor == null)
        {
            throw new NotImplementedException($"The type {type.FullName} does not have a constructor with the signature {typeof(IsolationLevel).FullName} and {typeof(MySqlClientDbProviderSettings).FullName}.");
        }

        var instance = (TProvider)ctor.Invoke(new object[] { isolationLevel, MySqlClientDbProviderSettings });

        return instance;
    }
}
