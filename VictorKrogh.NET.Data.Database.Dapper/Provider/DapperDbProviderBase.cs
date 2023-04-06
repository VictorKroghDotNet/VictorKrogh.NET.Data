using Dapper.Contrib.Extensions;
using Dapper;
using System.Data;
using VictorKrogh.NET.Data.Database.Provider;

namespace VictorKrogh.NET.Data.Database.Dapper.Provider;

public abstract class DapperDbProviderBase : DbProviderBase
{
    protected DapperDbProviderBase(IsolationLevel isolationLevel) 
        : base(isolationLevel)
    {
    }

    public override async Task<TModel?> GetAsync<TModel, TKey>(TKey key, int? commandTimeout = null)
        where TModel : class
    {
        return await Connection.GetAsync<TModel>(new object[] { key }, Transaction, commandTimeout);
    }

    public override async Task<IEnumerable<TModel>> GetAllAsync<TModel>(int? commandTimeout = null)
    {
        return await Connection.GetAllAsync<TModel>(Transaction, commandTimeout);
    }

    public override async Task<bool> InsertAsync<TModel>(TModel model, int? commandTimeout = null)
    {
        return await Connection.InsertAsync(model, Transaction, commandTimeout);
    }

    public override async Task<bool> UpdateAsync<TModel>(TModel model, int? commandTimeout = null)
    {
        return await Connection.UpdateAsync(model, Transaction, commandTimeout);
    }

    public override async Task<bool> DeleteAsync<TModel>(TModel model, int? commandTimeout = null)
    {
        return await Connection.DeleteAsync(model, Transaction, commandTimeout);
    }

    public override async Task<bool> DeleteAllAsync<TModel>(int? commandTimeout = null)
    {
        return await Connection.DeleteAllAsync<TModel>(Transaction, commandTimeout);
    }

    public override async Task<int> ExecuteAsync(string sql, object? parameters = null, int? commandTimeout = null, CommandType? commandType = null)
    {
        return await Connection.ExecuteAsync(sql, parameters, Transaction, commandTimeout, commandType);
    }

    public override async Task<IEnumerable<T>> ExecuteQueryAsync<T>(string sql, object? parameters = null, int? commandTimeout = null, CommandType? commandType = null)
    {
        return await Connection.QueryAsync<T>(sql, parameters, Transaction, commandTimeout, commandType);
    }

    public override async Task<T> ExecuteScalarAsync<T>(string sql, object? parameters = null, int? commandTimeout = null, CommandType? commandType = null)
    {
        return await Connection.ExecuteScalarAsync<T>(sql, parameters, Transaction, commandTimeout, commandType);
    }

    public override async Task<T> ExecuteSingleOrDefaultAsync<T>(string sql, object? parameters = null, int? commandTimeout = null, CommandType? commandType = null)
    {
        return await Connection.QuerySingleOrDefaultAsync<T>(sql, parameters, Transaction, commandTimeout, commandType);
    }

    public override async Task<IEnumerable<TModel>> QueryAsync<TModel>(string sql, object? parameters = null, int? commandTimeout = null, CommandType? commandType = null)
    {
        return await Connection.QueryAsync<TModel>(sql, parameters, Transaction, commandTimeout, commandType);
    }

    public override async Task<TModel> QueryFirstAsync<TModel>(string sql, object? parameters = null, int? commandTimeout = null, CommandType? commandType = null)
    {
        return await Connection.QueryFirstAsync<TModel>(sql, parameters, Transaction, commandTimeout, commandType);
    }

    public override async Task<TModel> QueryFirstOrDefaultAsync<TModel>(string sql, object? parameters = null, int? commandTimeout = null, CommandType? commandType = null)
    {
        return await Connection.QueryFirstOrDefaultAsync<TModel>(sql, parameters, Transaction, commandTimeout, commandType);
    }

    public override async Task<TModel> QuerySingleAsync<TModel>(string sql, object? parameters = null, int? commandTimeout = null, CommandType? commandType = null)
    {
        return await Connection.QuerySingleAsync<TModel>(sql, parameters, Transaction, commandTimeout, commandType);
    }

    public override async Task<TModel> QuerySingleOrDefaultAsync<TModel>(string sql, object? parameters = null, int? commandTimeout = null, CommandType? commandType = null)
    {
        return await Connection.QuerySingleOrDefaultAsync<TModel>(sql, parameters, Transaction, commandTimeout, commandType);
    }
}
