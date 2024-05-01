using ApiDevBP.Data;
using ApiDevBP.Entities;
using ApiDevBP.Models;
using ApiDevBP.Services;
using Microsoft.EntityFrameworkCore;

public class UserService : IUserService
{
    private readonly DatabaseDbContext _dbContext;

    public UserService(DatabaseDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task SaveUser(UserModel user)
    {
        var usuario = new UserEntity()
        {
            Name = user.Name,
            Lastname = user.Lastname
        };
        _dbContext.UserEntities.Add(usuario);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<List<UserModel>> GetUsersByLastName(string lastName)
    {
        var usersWithSameLastName = await _dbContext.UserEntities
            .Where(u => u.Lastname == lastName)
            .ToListAsync();

        return usersWithSameLastName.Select(x => new UserModel()
        {
            Name = x.Name,
            Lastname = x.Lastname
        }).ToList();
    }

    public async Task<List<UserModel>> GetAllUsers()
    {
        try
        {
            var users = await _dbContext.UserEntities.ToListAsync();

            return users.Select(x => new UserModel()
            {
                Name = x.Name,
                Lastname = x.Lastname
            }).ToList();
        }
        catch (Exception ex)
        {

            throw;
        }

    }

    public async Task<UserModel> GetUserById(int id)
    {
        var user = await _dbContext.UserEntities.FindAsync(id);
        if (user == null)
            return null;

        return new UserModel()
        {
            Name = user.Name,
            Lastname = user.Lastname
        };
    }

    public async Task UpdateUser(int id, UserModel user)
    {
        var existingUser = await _dbContext.UserEntities.FindAsync(id);
        if (existingUser != null)
        {
            existingUser.Name = user.Name;
            existingUser.Lastname = user.Lastname;
            await _dbContext.SaveChangesAsync();
        }
    }

    public async Task DeleteUser(int id)
    {
        var existingUser = await _dbContext.UserEntities.FindAsync(id);
        if (existingUser != null)
        {
            _dbContext.UserEntities.Remove(existingUser);
            await _dbContext.SaveChangesAsync();
        }
    }
}
