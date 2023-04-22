using System.Data.SqlClient;
using VictorKrogh.NET.Data.Database.Provider;

namespace VictorKrogh.NET.Data.Database.Dapper.Provider.Sql;

public sealed class SqlClientDbProviderSettings : IDbProviderSettings
{
    public string? ConnectionString { get; set; }
    public SqlCredential? SqlCredential { get; set; }
}
