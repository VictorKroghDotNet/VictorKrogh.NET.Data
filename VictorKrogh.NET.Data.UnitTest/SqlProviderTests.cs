using VictorKrogh.NET.Data.Database.Dapper.Provider.Sql;
using VictorKrogh.NET.Data.UnitTest.Mock;

namespace VictorKrogh.NET.Data.UnitTest;

public class SqlProviderTests
{
    public const string TestingSchema = "test";

    private IMockSqlClientDbProvider? MockProvider { get; set; }

    [SetUp]
    public void Setup()
    {
        var sqlClientDbProviderSettings = new SqlClientDbProviderSettings();

        var sqlClientDbProviderFactory = new SqlClientDbProviderFactory<MockSqlClientDbProvider>(sqlClientDbProviderSettings);

        MockProvider = sqlClientDbProviderFactory.CreateProvider();
    }

    [Test]
    public void MockProvider_InstanceOf_MockSqlClientDbProvider()
    {
        Assert.That(MockProvider, Is.InstanceOf<MockSqlClientDbProvider>());
    }

    [Test]
    public void GetQualifiedTableName_Equals_MockModel()
    {
        var mockModelTableName = MockProvider?.GetQualifiedTableName<MockModel>() ?? string.Empty;

        Assert.That(mockModelTableName, Is.EqualTo($"..[{nameof(MockModel)}]"));
    }

    [Test]
    public void GetQualifiedTableName_Equals_MockSchemaModel()
    {
        var mockModelTableName = MockProvider?.GetQualifiedTableName<MockSchemaModel>() ?? string.Empty;

        Assert.That(mockModelTableName, Is.EqualTo($"[{TestingSchema}].[{nameof(MockModel)}]"));
    }
}
