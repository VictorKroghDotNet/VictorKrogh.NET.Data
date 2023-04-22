using System.ComponentModel.DataAnnotations.Schema;
using VictorKrogh.NET.Data.Database.Model;

namespace VictorKrogh.NET.Data.UnitTest.Mock;

[Table(nameof(MockModel))]
public class MockModel : DbModelBase
{
}

[Table(nameof(MockModel))]
[Schema(SqlProviderTests.TestingSchema)]
public class MockSchemaModel : DbModelBase
{
}