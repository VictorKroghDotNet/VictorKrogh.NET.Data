using System.Data;
using VictorKrogh.NET.Data.Database.Model;
using VictorKrogh.NET.Data.Database.Provider;
using VictorKrogh.NET.Data.Repository;

namespace VictorKrogh.NET.Data.Database.Repository;

public abstract class DbRepositoryBase : RepositoryBase<IDbProvider>
{
    protected DbRepositoryBase(IDbProvider provider)
        : base(provider)
    {
    }

    protected async Task<int> ExecuteAsync(string sql, object? parameters = null, int? commandTimeout = null, CommandType? commandType = null)
    {
        return await Provider.ExecuteAsync(sql, parameters, commandTimeout, commandType);
    }

    protected async Task<T> ExecuteScalarAsync<T>(string sql, object? parameters = null, int? commandTimeout = null, CommandType? commandType = null)
    {
        return await Provider.ExecuteScalarAsync<T>(sql, parameters, commandTimeout, commandType);
    }

    protected async Task<T> ExecuteSingleOrDefaultAsync<T>(string sql, object? parameters = null, int? commandTimeout = null, CommandType? commandType = null)
    {
        return await Provider.ExecuteSingleOrDefaultAsync<T>(sql, parameters, commandTimeout, commandType);
    }

    protected async Task<IEnumerable<T>> ExecuteQueryAsync<T>(string sql, object? parameters = null, int? commandTimeout = null, CommandType? commandType = null)
    {
        return await Provider.ExecuteQueryAsync<T>(sql, parameters, commandTimeout, commandType);
    }
}

public abstract class DbRepositoryBase<TModel, TKey> : DbReadOnlyRepositoryBase<TModel, TKey>, IRepository<TModel, TKey>
    where TModel : DbModelBase
    where TKey : notnull
{
    protected DbRepositoryBase(IDbProvider provider)
        : base(provider)
    {
    }

    public async virtual Task<bool> AddAsync(TModel model)
    {
        return await Provider.InsertAsync(model);
    }

    public async virtual Task<bool> UpdateAsync(TModel model)
    {
        return await Provider.UpdateAsync(model);
    }

    public virtual Task<bool> AddOrUpdateAsync(TModel model)
    {
        throw new NotImplementedException();
    }

    public async virtual Task<bool> DeleteAsync(TModel model)
    {
        return await Provider.DeleteAsync(model);
    }

    public async virtual Task<bool> DeleteAllAsync()
    {
        return await Provider.DeleteAllAsync<TModel>();
    }
}