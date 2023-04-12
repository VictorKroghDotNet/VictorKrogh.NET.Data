using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VictorKrogh.NET.Data.Database.Model;

namespace VictorKrogh.NET.Data.UnitTest.Mock;

[Table("VKProject")]
public class MockVKProject : DbModelBase
{
    [Key]
    public int Id { get; set; }

    public string? Name { get; set; }
    public string? Description { get; set; }
    public DateTime Created { get; set; }
}
