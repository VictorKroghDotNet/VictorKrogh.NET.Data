using VictorKrogh.NET.Data.Database.Provider;

namespace VictorKrogh.NET.Data.Database.Dapper.Provider.MySql;

public sealed class MySqlClientDbProviderSettings : IDbProviderSettings
{
    public string? ConnectionString { get; set; }
}
