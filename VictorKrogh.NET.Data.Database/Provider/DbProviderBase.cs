using System.Data;
using VictorKrogh.NET.Data.Database.Model;
using VictorKrogh.NET.Data.Provider;

namespace VictorKrogh.NET.Data.Database.Provider;

public abstract class DbProviderBase : ProviderBase, IDbProvider
{
    private IDbConnection? m_DbConnection;
    private IDbTransaction? m_DbTransaction;
    private bool m_Committed = false;

    protected DbProviderBase(IsolationLevel isolationLevel)
        : base(isolationLevel)
    {
    }

    public IDbConnection Connection => m_DbConnection ??= CreateConnection();

    public IDbTransaction Transaction
    {
        get
        {
            if (m_DbTransaction != null)
            {
                return m_DbTransaction;
            }

            if (Connection.State != ConnectionState.Open)
            {
                Connection.Open();
            }

            return m_DbTransaction = Connection.BeginTransaction();
        }
    }

    protected abstract IDbConnection CreateConnection();

    public abstract Task<TModel?> GetAsync<TModel, TKey>(TKey key, int? commandTimeout = null) where TModel : DbModelBase where TKey : notnull;
    public abstract Task<IEnumerable<TModel>> GetAllAsync<TModel>(int? commandTimeout = null) where TModel : DbModelBase;
    public abstract Task<bool> InsertAsync<TModel>(TModel model, int? commandTimeout = null) where TModel : DbModelBase;
    public abstract Task<bool> UpdateAsync<TModel>(TModel model, int? commandTimeout = null) where TModel : DbModelBase;
    public abstract Task<bool> DeleteAsync<TModel>(TModel model, int? commandTimeout = null) where TModel : DbModelBase;
    public abstract Task<bool> DeleteAllAsync<TModel>(int? commandTimeout = null) where TModel : DbModelBase;
    public abstract Task<TModel> QuerySingleAsync<TModel>(string sql, object? parameters = null, int? commandTimeout = null, CommandType? commandType = null) where TModel : DbModelBase;
    public abstract Task<TModel> QuerySingleOrDefaultAsync<TModel>(string sql, object? parameters = null, int? commandTimeout = null, CommandType? commandType = null) where TModel : DbModelBase;
    public abstract Task<TModel> QueryFirstAsync<TModel>(string sql, object? parameters = null, int? commandTimeout = null, CommandType? commandType = null) where TModel : DbModelBase;
    public abstract Task<TModel> QueryFirstOrDefaultAsync<TModel>(string sql, object? parameters = null, int? commandTimeout = null, CommandType? commandType = null) where TModel : DbModelBase;
    public abstract Task<IEnumerable<TModel>> QueryAsync<TModel>(string sql, object? parameters = null, int? commandTimeout = null, CommandType? commandType = null) where TModel : DbModelBase;
    public abstract Task<int> ExecuteAsync(string sql, object? parameters = null, int? commandTimeout = null, CommandType? commandType = null);
    public abstract Task<T> ExecuteScalarAsync<T>(string sql, object? parameters = null, int? commandTimeout = null, CommandType? commandType = null);
    public abstract Task<T> ExecuteSingleOrDefaultAsync<T>(string sql, object? parameters = null, int? commandTimeout = null, CommandType? commandType = null);
    public abstract Task<IEnumerable<T>> ExecuteQueryAsync<T>(string sql, object? parameters = null, int? commandTimeout = null, CommandType? commandType = null);

    public override void Complete()
    {
        if (m_DbTransaction == null)
        {
            return;
        }

        m_DbTransaction.Commit();
        m_Committed = true;
    }

    public override void Rollback()
    {
        if (m_DbTransaction == null)
        {
            return;
        }

        m_DbTransaction?.Rollback();
    }

    protected override void DisposeManagedState()
    {
        if (m_DbTransaction != null)
        {
            if (!m_Committed)
            {
                Rollback();
            }

            m_DbConnection?.Dispose();
        }

        if (m_DbConnection?.State != ConnectionState.Closed)
        {
            m_DbConnection?.Close();
        }

        m_DbConnection?.Dispose();
    }
}
