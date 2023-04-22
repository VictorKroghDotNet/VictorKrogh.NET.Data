using System.Data;
using System.Data.SqlClient;
using VictorKrogh.NET.Data.Database.Provider;

namespace VictorKrogh.NET.Data.Database.Dapper.Provider.Sql;

public interface ISqlClientDbProvider : IDbProvider
{
}

public abstract class SqlClientDbProviderBase : DapperDbProviderBase, ISqlClientDbProvider
{
    protected SqlClientDbProviderBase(IsolationLevel isolationLevel, SqlClientDbProviderSettings sqlClientDbProviderSettings) 
        : base(isolationLevel)
    {
        SqlClientDbProviderSettings = sqlClientDbProviderSettings;
    }

    private SqlClientDbProviderSettings SqlClientDbProviderSettings { get; }

    protected override IDbConnection CreateConnection()
    {
        return new SqlConnection(SqlClientDbProviderSettings.ConnectionString, SqlClientDbProviderSettings.SqlCredential);
    }
}
