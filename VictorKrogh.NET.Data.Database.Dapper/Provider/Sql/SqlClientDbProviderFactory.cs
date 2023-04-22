using System.Data;
using System.Reflection;
using VictorKrogh.NET.Data.Provider;

namespace VictorKrogh.NET.Data.Database.Dapper.Provider.Sql;

public sealed class SqlClientDbProviderFactory<TProvider> : IProviderFactory<TProvider>
    where TProvider : ISqlClientDbProvider
{
    public SqlClientDbProviderFactory(SqlClientDbProviderSettings sqlClientDbProviderSettings)
    {
        SqlClientDbProviderSettings = sqlClientDbProviderSettings;
    }

    private SqlClientDbProviderSettings SqlClientDbProviderSettings { get; }

    public TProvider CreateProvider(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
    {
        var type = typeof(TProvider);

        var ctor = type.GetConstructor(BindingFlags.Instance | BindingFlags.Public, null, new[] { typeof(IsolationLevel), typeof(SqlClientDbProviderSettings) }, null);
        if (ctor == null)
        {
            throw new NotImplementedException($"The type {type.FullName} does not have a constructor with the signature {typeof(IsolationLevel).FullName} and {typeof(SqlClientDbProviderSettings).FullName}.");
        }

        var instance = (TProvider)ctor.Invoke(new object[] { isolationLevel, SqlClientDbProviderSettings });

        return instance;
    }
}
