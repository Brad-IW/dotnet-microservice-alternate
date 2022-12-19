using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserAPI.Models;

[Table("users")]
public class UserDto
{
    [Key]
    [Column("id")]
    public int Id { get; set; }
    [Column("firstname")]
    public string FirstName { get; set; }
    [Column("lastname")]
    public string LastName { get; set; }
    [Column("age")]
    public int Age { get; set; }
    [Column("sex")]
    public string Sex { get; set; } 
}
