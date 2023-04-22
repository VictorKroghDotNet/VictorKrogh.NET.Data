using VictorKrogh.NET.Data.Database.Dapper.Provider.MySql;
using VictorKrogh.NET.Data.UnitTest.Mock;

namespace VictorKrogh.NET.Data.UnitTest;

public class MySqlProviderTests
{
    private IMockMySqlClientDbProvider? MockProvider { get; set; }

    [SetUp]
    public void Setup()
    {
        var mysqlClientDbProviderSettings = new MySqlClientDbProviderSettings();

        var mySqlClientDbProviderFactory = new MySqlClientDbProviderFactory<MockMySqlClientDbProvider>(mysqlClientDbProviderSettings);

        MockProvider = mySqlClientDbProviderFactory.CreateProvider();
    }

    [Test]
    public void MockProvider_InstanceOf_MockMySqlClientDbProvider()
    {
        Assert.That(MockProvider, Is.InstanceOf<MockMySqlClientDbProvider>());
    }

    [Test]
    public void GetQualifiedTableName_Equals_MockModel()
    {
        var mockModelTableName = MockProvider?.GetQualifiedTableName<MockModel>() ?? string.Empty;

        Assert.That(mockModelTableName, Is.EqualTo($"`{nameof(MockModel)}`"));
    }
}
