using ApiDevBP.Data;
using ApiDevBP.Entities;
using ApiDevBP.Models;
using ApiDevBP.Services;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

public class UserService : IUserService
{
    private readonly DatabaseDbContext _dbContext;
    private readonly IMapper _mapper;

    public UserService(DatabaseDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task SaveUser(UserModel user)
    {
        var usuario = _mapper.Map<UserEntity>(user);
        _dbContext.UserEntities.Add(usuario);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<List<UserModel>> GetUsersByLastName(string lastName)
    {
        var usersWithSameLastName = await _dbContext.UserEntities
            .Where(u => u.Lastname == lastName)
            .ToListAsync();

        return _mapper.Map<List<UserModel>>(usersWithSameLastName);
    }

    public async Task<List<UserEntity>> GetAllUsersId()
    {
        var users = await _dbContext.UserEntities.ToListAsync();
        return users;
    }
    public async Task<List<UserModel>> GetAllUsers()
    {
        var users = await _dbContext.UserEntities.ToListAsync();
        return _mapper.Map<List<UserModel>>(users);
    }

    public async Task<UserModel> GetUserById(int id)
    {
        var user = await _dbContext.UserEntities.FindAsync(id);
        return _mapper.Map<UserModel>(user);
    }

    public async Task UpdateUser(int id, UserModel user)
    {
        var existingUser = await _dbContext.UserEntities.FindAsync(id);
        if (existingUser != null)
        {
            _mapper.Map(user, existingUser);
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
