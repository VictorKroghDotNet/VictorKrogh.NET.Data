using VictorKrogh.NET.Data.Database.Repository;
using VictorKrogh.NET.Data.Repository;

namespace VictorKrogh.NET.Data.UnitTest.Mock;

internal interface IMockVKProjectRepository : IRepository<MockVKProject, int>
{
}

internal class MockVKProjectRepository : DbRepositoryBase<MockVKProject, int>, IMockVKProjectRepository
{
    public MockVKProjectRepository(IMockMySqlClientDbClientProvider provider)
        : base(provider)
    {
    }
}
