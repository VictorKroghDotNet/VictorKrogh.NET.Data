namespace VictorKrogh.NET.Data.Repository;

public interface IRepository
{
}

public interface IRepository<TModel> : IRepository where TModel : class
{
}

public interface IWriteRepository<TModel> : IRepository<TModel> where TModel : class
{
    Task<bool> AddAsync(TModel model);
    Task<bool> UpdateAsync(TModel model);
    Task<bool> AddOrUpdateAsync(TModel model);
    Task<bool> DeleteAsync(TModel model);
    Task<bool> DeleteAllAsync();
}

public interface IReadOnlyRepository<TModel> : IRepository<TModel> where TModel : class
{
    Task<TModel?> GetFirstOrDefaultAsync();
    Task<IEnumerable<TModel?>> GetAsync();
}

public interface IReadOnlyRepository<TModel, TKey> : IReadOnlyRepository<TModel>
    where TModel : class
    where TKey : notnull
{
    Task<TModel?> GetAsync(TKey key);
}

public interface IRepository<TModel, TKey> : IReadOnlyRepository<TModel, TKey>, IWriteRepository<TModel>
    where TModel : class
    where TKey : notnull
{
}
