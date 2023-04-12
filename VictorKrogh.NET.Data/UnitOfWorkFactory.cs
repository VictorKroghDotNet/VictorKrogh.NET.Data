using System.Data;

namespace VictorKrogh.NET.Data;

public interface IUnitOfWorkFactory
{
    IUnitOfWork Create(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);
}

public sealed class UnitOfWorkFactory : IUnitOfWorkFactory
{
    public UnitOfWorkFactory(IServiceProvider serviceProvider)
    {
        ServiceProvider = serviceProvider;
    }

    private IServiceProvider ServiceProvider { get; }

    public IUnitOfWork Create(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
    {
        return new UnitOfWork(ServiceProvider, isolationLevel);
    }
}
