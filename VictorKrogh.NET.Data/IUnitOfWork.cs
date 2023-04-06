using System.Data;
using VictorKrogh.NET.Data.Provider;
using VictorKrogh.NET.Data.Repository;

namespace VictorKrogh.NET.Data;

public interface IUnitOfWork : IDisposable, IProviderFactory
{
    IsolationLevel IsolationLevel { get; }

    bool IsCompleted { get; }

    void Complete();

    TRepository GetRepository<TRepository>() where TRepository : IRepository;
}
