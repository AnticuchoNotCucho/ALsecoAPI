using AlsecoWebAPI.Interfaces;
using AlsecoWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AlsecoWebAPI.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApiDbContext _context;
    
    public UserRepository(ApiDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<User>> GetAllUsers()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<User> GetUserById(int id)
    {
        return await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<bool> DeleteUser(int id)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
        if (user == null)
        {
            return false;
        }
        _context.Users.Remove(user);
        _context.SaveChanges();
            return true;
    }

    public async Task<bool> UpdateUser([FromBody] User user)
    {
        var userToUpdate = await _context.Users.FirstOrDefaultAsync(x => x.Id == user.Id);
        if (userToUpdate == null)
        {
            return false;
        }
        userToUpdate.Username = user.Username;
        userToUpdate.Name = user.Name;
        userToUpdate.Password = user.Password;
        userToUpdate.Surname = user.Surname;
        userToUpdate.Rut = user.Rut;
        userToUpdate.Address = user.Address;
        
        _context.Users.Update(userToUpdate);
        _context.SaveChanges();
        return true;
    }

    public Task<bool> AddUser(User user)
    {
        var userExists = _context.Users.Any(x => x.Username == user.Username);
        if (userExists)
        {
            return Task.FromResult(false);
        }
        _context.Users.Add(user);
        _context.SaveChanges();
        return Task.FromResult(true);
    }
}