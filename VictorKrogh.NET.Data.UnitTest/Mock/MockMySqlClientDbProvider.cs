using System.Data;
using VictorKrogh.NET.Data.Database.Dapper.Provider.MySql;

namespace VictorKrogh.NET.Data.UnitTest.Mock;

public interface IMockMySqlClientDbProvider : IMySqlClientDbProvider
{
}

public class MockMySqlClientDbProvider : MySqlClientDbProviderBase, IMockMySqlClientDbProvider
{
    public MockMySqlClientDbProvider(IsolationLevel isolationLevel, MySqlClientDbProviderSettings mySqlClientDbProviderSettings)
        : base(isolationLevel, mySqlClientDbProviderSettings)
    {
    }
}
