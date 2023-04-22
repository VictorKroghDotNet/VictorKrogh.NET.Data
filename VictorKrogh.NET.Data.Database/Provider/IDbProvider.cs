using System.Data;
using VictorKrogh.NET.Data.Database.Model;
using VictorKrogh.NET.Data.Provider;

namespace VictorKrogh.NET.Data.Database.Provider;

public interface IDbProvider : IProvider
{
    string GetQualifiedTableName<TModel>() where TModel : DbModelBase;

    Task<TModel?> GetAsync<TModel, TKey>(TKey key, int? commandTimeout = null) where TModel : DbModelBase where TKey : notnull;
    Task<IEnumerable<TModel>> GetAllAsync<TModel>(int? commandTimeout = null) where TModel : DbModelBase;
    Task<bool> InsertAsync<TModel>(TModel model, int? commandTimeout = null) where TModel : DbModelBase;
    Task<bool> UpdateAsync<TModel>(TModel model, int? commandTimeout = null) where TModel : DbModelBase;
    Task<bool> DeleteAsync<TModel>(TModel model, int? commandTimeout = null) where TModel : DbModelBase;
    Task<bool> DeleteAllAsync<TModel>(int? commandTimeout = null) where TModel : DbModelBase;
    Task<TModel> QuerySingleAsync<TModel>(string sql, object? parameters = null, int? commandTimeout = null, CommandType? commandType = null) where TModel : DbModelBase;
    Task<TModel> QuerySingleOrDefaultAsync<TModel>(string sql, object? parameters = null, int? commandTimeout = null, CommandType? commandType = null) where TModel : DbModelBase;
    Task<TModel> QueryFirstAsync<TModel>(string sql, object? parameters = null, int? commandTimeout = null, CommandType? commandType = null) where TModel : DbModelBase;
    Task<TModel> QueryFirstOrDefaultAsync<TModel>(string sql, object? parameters = null, int? commandTimeout = null, CommandType? commandType = null) where TModel : DbModelBase;
    Task<IEnumerable<TModel>> QueryAsync<TModel>(string sql, object? parameters = null, int? commandTimeout = null, CommandType? commandType = null) where TModel : DbModelBase;

    Task<int> ExecuteAsync(string sql, object? parameters = null, int? commandTimeout = null, CommandType? commandType = null);
    Task<T> ExecuteScalarAsync<T>(string sql, object? parameters = null, int? commandTimeout = null, CommandType? commandType = null);
    Task<T> ExecuteSingleOrDefaultAsync<T>(string sql, object? parameters = null, int? commandTimeout = null, CommandType? commandType = null);
    Task<IEnumerable<T>> ExecuteQueryAsync<T>(string sql, object? parameters = null, int? commandTimeout = null, CommandType? commandType = null);
}
