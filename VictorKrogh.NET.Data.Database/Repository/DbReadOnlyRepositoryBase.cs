using System.Data;
using VictorKrogh.NET.Data.Database.Model;
using VictorKrogh.NET.Data.Database.Provider;
using VictorKrogh.NET.Data.Repository;

namespace VictorKrogh.NET.Data.Database.Repository;

public abstract class DbReadOnlyRepositoryBase<TModel> : DbRepositoryBase, IReadOnlyRepository<TModel>
    where TModel : DbModelBase
{
    protected DbReadOnlyRepositoryBase(IDbProvider provider)
        : base(provider)
    {
    }

    protected async virtual Task<TModel?> QuerySingleAsync(string sql, object? parameters = null, int? commandTimeout = null, CommandType? commandType = null)
    {
        return await Provider.QuerySingleAsync<TModel>(sql, parameters, commandTimeout, commandType);
    }

    protected async virtual Task<TModel?> QuerySingleOrDefaultAsync(string sql, object? parameters = null, int? commandTimeout = null, CommandType? commandType = null)
    {
        return await Provider.QuerySingleOrDefaultAsync<TModel>(sql, parameters, commandTimeout, commandType);
    }

    protected async virtual Task<TModel?> QueryFirstAsync(string sql, object? parameters = null, int? commandTimeout = null, CommandType? commandType = null)
    {
        return await Provider.QueryFirstAsync<TModel>(sql, parameters, commandTimeout, commandType);
    }

    protected async virtual Task<TModel?> QueryFirstOrDefaultAsync(string sql, object? parameters = null, int? commandTimeout = null, CommandType? commandType = null)
    {
        return await Provider.QueryFirstOrDefaultAsync<TModel>(sql, parameters, commandTimeout, commandType);
    }

    protected async virtual Task<IEnumerable<TModel?>> QueryAsync(string sql, object? parameters = null, int? commandTimeout = null, CommandType? commandType = null)
    {
        return await Provider.QueryAsync<TModel>(sql, parameters, commandTimeout, commandType);
    }

    public abstract Task<IEnumerable<TModel?>> GetAsync();

    public async virtual Task<TModel?> GetFirstOrDefaultAsync()
    {
        var result = await GetAsync();
        if (result == default)
        {
            return default;
        }

        return result.FirstOrDefault();
    }
}

public abstract class DbReadOnlyRepositoryBase<TModel, TKey> : DbReadOnlyRepositoryBase<TModel>, IReadOnlyRepository<TModel, TKey>
    where TModel : DbModelBase
    where TKey : notnull
{
    protected DbReadOnlyRepositoryBase(IDbProvider provider)
        : base(provider)
    {
    }

    public async Task<TModel?> GetAsync(TKey key)
    {
        return await Provider.GetAsync<TModel, TKey>(key);
    }

    public override async Task<IEnumerable<TModel?>> GetAsync()
    {
        return await Provider.GetAllAsync<TModel>();
    }
}