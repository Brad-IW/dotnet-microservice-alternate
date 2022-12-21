using Microsoft.EntityFrameworkCore;
using UserAPI.Models;

namespace UserAPI;

public class UsersContext : DbContext
{
    public UsersContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<UserDto> Users { get; set; }
}
