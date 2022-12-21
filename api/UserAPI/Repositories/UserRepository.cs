using Microsoft.EntityFrameworkCore;
using UserAPI.Models;

namespace UserAPI.Repositories;

public class UserRepository : IUserRepository
{
    private readonly UsersContext _usersContext;

    public UserRepository(UsersContext usersContext)
    {
        _usersContext = usersContext;
    }

    public async Task<User?> CreateUser(User user)
    {
        if (await _usersContext.Users
           .Where(u => u.Id == user.Id)
           .AnyAsync())
        {
            return null;
        }

        var res = await _usersContext.AddAsync((UserDto)user);
        await _usersContext.SaveChangesAsync();

        return (User)res.Entity;
    }

    public async Task DeleteUser(int id)
    {
        var user = _usersContext.Users
            .FirstOrDefault(u => u.Id == id);

        if (user is not null) 
        {
            _usersContext.Remove(user);
            await _usersContext.SaveChangesAsync();
        }
    }

    public async Task<User?> GetUser(int id)
    {
        var user = await _usersContext.Users
            .FirstOrDefaultAsync(u => u.Id == id);

        return (User?)user;
    }

    public async Task<IEnumerable<User>> GetUsers()
    {
        return await _usersContext.Users
            .Select(u => (User)u)
            .ToListAsync(); 
    }

    public async Task<User?> UpdateUser(User user)
    {
        var model = await _usersContext.Users
            .FirstOrDefaultAsync(u => u.Id == user.Id);

        if (model is not null)
        {
            model.Id = user.Id;
            model.FirstName = user.FirstName;
            model.LastName = user.LastName;
            model.Age = user.Age;
            model.Sex = user.Sex;

            await _usersContext.SaveChangesAsync();
            return (User?)model;
        }

        return null;
    }
}
