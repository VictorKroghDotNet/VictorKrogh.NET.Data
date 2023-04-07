using System.Data;
using VictorKrogh.NET.Data.Database.Dapper.Provider.MySql;

namespace VictorKrogh.NET.Data.UnitTest.Mock;

public interface IMockMySqlClientDbClientProvider : IMySqlClientDbProvider
{
}

internal sealed class MockMySqlClientDbClientProvider : MySqlClientDbProviderBase, IMockMySqlClientDbClientProvider
{
    public MockMySqlClientDbClientProvider(IsolationLevel isolationLevel, MySqlClientDbProviderSettings mySqlClientDbProviderSettings) 
        : base(isolationLevel, mySqlClientDbProviderSettings)
    {
    }
}
