using UserAPI.Models;

namespace UserAPI.Repositories;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetUsers();
    Task<User?> GetUser(int id);
    Task<User?> CreateUser(User user);
    Task<User?> UpdateUser(User user);
    Task DeleteUser(int id);
}
