using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using UserAPI.Models;

namespace UserAPI;

public class UsersContext : DbContext
{
    public UsersContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<UserDto> Users { get; set; }
}
