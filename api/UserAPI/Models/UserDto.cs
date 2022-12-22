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
    public string? FirstName { get; set; }
    [Column("lastname")]
    public string? LastName { get; set; }
    [Column("age")]
    public int Age { get; set; }
    [Column("sex")]
    public string? Sex { get; set; }

    public static explicit operator User?(UserDto dto)
        => FromDto(dto);

    public static explicit operator UserDto?(User user)
        => ToDto(user);

    private static User? FromDto(UserDto? dto)
    {
        if (dto is null)
        {
            return null;
        }

        return new User
        {
            Id = dto.Id,
            FirstName = dto?.FirstName ?? string.Empty,
            LastName = dto?.LastName ?? string.Empty,
            Age = dto?.Age ?? 0,
            Sex = dto?.Sex ?? string.Empty,
        };
    }

    private static UserDto? ToDto(User? user)
    {
        if (user is null)
        {
            return null;
        }

        return new UserDto
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Age = user.Age,
            Sex = user.Sex,
        };
    }
}
