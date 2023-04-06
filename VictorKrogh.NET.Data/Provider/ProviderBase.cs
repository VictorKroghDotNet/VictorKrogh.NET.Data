using System.Data;
using VictorKrogh.NET.Disposable;

namespace VictorKrogh.NET.Data.Provider;

public abstract class ProviderBase : DisposableObject, IProvider
{
    public ProviderBase(IsolationLevel isolationLevel)
    {
        IsolationLevel = isolationLevel;
    }

    protected IsolationLevel IsolationLevel { get; }

    public virtual void Complete()
    {
    }

    public virtual void Rollback()
    {
    }
}
