using AlsecoWebAPI.Models;

namespace AlsecoWebAPI.Interfaces;

public interface IUserRepository 
{
    Task<IEnumerable<User>> GetAllUsers();
    Task<User> GetUserById(int id);
    Task<bool> DeleteUser(int id);
    Task<bool> UpdateUser(User user);
    Task<bool> AddUser(User user);
    
}