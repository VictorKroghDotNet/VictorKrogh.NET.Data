using MySql.Data.MySqlClient;
using System.Data;
using VictorKrogh.NET.Data.Database.Provider;

namespace VictorKrogh.NET.Data.Database.Dapper.Provider.MySql;

public interface IMySqlClientDbProvider : IDbProvider
{
}

public abstract class MySqlClientDbProviderBase : DapperDbProviderBase, IMySqlClientDbProvider
{
    public MySqlClientDbProviderBase(IsolationLevel isolationLevel, MySqlClientDbProviderSettings mySqlClientDbProviderSettings)
        : base(isolationLevel)
    {
        MySqlClientDbProviderSettings = mySqlClientDbProviderSettings ?? throw new ArgumentNullException(nameof(mySqlClientDbProviderSettings));
    }

    private MySqlClientDbProviderSettings? MySqlClientDbProviderSettings { get; }

    protected override IDbConnection CreateConnection()
    {
        return new MySqlConnection(MySqlClientDbProviderSettings?.ConnectionString);
    }
}
