using Microsoft.Extensions.DependencyInjection;
using System.Data;
using VictorKrogh.NET.Data.Provider;
using VictorKrogh.NET.Data.Repository;
using VictorKrogh.NET.Disposable;

namespace VictorKrogh.NET.Data;

internal sealed class UnitOfWork : DisposableObject, IUnitOfWork
{
    public UnitOfWork(IServiceProvider serviceProvider, IsolationLevel isolationLevel)
    {
        ServiceProvider = serviceProvider;
        IsolationLevel = isolationLevel;

        Providers = new List<IProvider>();
    }

    private IServiceProvider ServiceProvider { get; }
    public IsolationLevel IsolationLevel { get; }
    public bool IsCompleted { get; private set; }
    private IList<IProvider> Providers { get; }

    public void Complete()
    {
        foreach (var provider in Providers)
        {
            provider.Complete();
        }

        IsCompleted = true;
    }

    public TRepository GetRepository<TRepository>() where TRepository : IRepository
    {
        return ServiceProvider.GetRequiredService<TRepository>();
    }

    public TProvider CreateProvider<TProvider>(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted) where TProvider : IProvider
    {
        var providerFactory = ServiceProvider.GetRequiredService<IProviderFactory<TProvider>>();

        var provider = providerFactory.CreateProvider(isolationLevel);

        Providers.Add(provider);

        return provider;
    }

    protected override void DisposeManagedState()
    {
        Providers.Clear();
    }
}
