using VictorKrogh.NET.Data.Provider;

namespace VictorKrogh.NET.Data.Repository;

public abstract class RepositoryBase<TProvider> where TProvider : IProvider
{
    public RepositoryBase(TProvider provider)
    {
        Provider = provider;
    }

    protected TProvider Provider { get; }
}
