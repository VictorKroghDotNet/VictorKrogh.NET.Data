using Microsoft.Extensions.DependencyInjection;
using VictorKrogh.NET.Data.Database.Dapper.Provider.MySql;
using VictorKrogh.NET.Data.Provider;
using VictorKrogh.NET.Data.UnitTest.Mock;
using VictorKrogh.NET.Extensions.DependencyInjection;

namespace VictorKrogh.NET.Data.UnitTest;

[TestFixture]
public class ServiceCollectionTest
{
    private IServiceProvider ServiceProvider { get; set; }
    private IServiceScope Scope { get; set; }
    private IUnitOfWork UnitOfWork { get; set; }

    [SetUp]
    public void Setup()
    {
        var mysqlClientProviderSettings = new MySqlClientDbProviderSettings();

        var serviceCollection = new ServiceCollection();

        serviceCollection.AddUnitOfWork();

        serviceCollection.AddMySqlClientDbProviderFactory<MockMySqlClientDbClientProvider>(mysqlClientProviderSettings);

        serviceCollection.AddMySqlClientDbProvder<MockMySqlClientDbClientProvider>();

        serviceCollection.AddRepositories<MockMySqlClientDbClientProvider>();

        ServiceProvider = serviceCollection.BuildServiceProvider();

        Scope = ServiceProvider.CreateScope();

        UnitOfWork = Scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
    }

    [TearDown]
    public void TearDown()
    {
        UnitOfWork?.Complete();

        Scope?.Dispose();
    }

    [Test]
    public Task Test_Unit_Of_Work_Get_Repository()
    {
        try
        {
            var mockVKProjectRepository = UnitOfWork.GetRepository<IMockVKProjectRepository>();

            Assert.IsAssignableFrom<MockVKProjectRepository>(mockVKProjectRepository);
        }
        catch(Exception ex)
        {
            Assert.Fail(ex.Message);
        }

        return Task.CompletedTask;
    }
}
