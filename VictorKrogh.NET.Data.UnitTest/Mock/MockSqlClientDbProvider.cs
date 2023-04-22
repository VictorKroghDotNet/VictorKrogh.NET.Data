using System.Data;
using VictorKrogh.NET.Data.Database.Dapper.Provider.Sql;

namespace VictorKrogh.NET.Data.UnitTest.Mock;

public interface IMockSqlClientDbProvider : ISqlClientDbProvider
{
}

public class MockSqlClientDbProvider : SqlClientDbProviderBase, IMockSqlClientDbProvider
{
    public MockSqlClientDbProvider(IsolationLevel isolationLevel, SqlClientDbProviderSettings sqlClientDbProviderSettings)
        : base(isolationLevel, sqlClientDbProviderSettings)
    {
    }
}
