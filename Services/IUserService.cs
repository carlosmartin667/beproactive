using ApiDevBP.Entities;
using ApiDevBP.Models;

namespace ApiDevBP.Services
{
    public interface IUserService
    {
        Task SaveUser(UserModel user);
        Task<List<UserModel>> GetUsersByLastName(string lastName);
        Task<List<UserModel>> GetAllUsers();
        Task<List<UserEntity>> GetAllUsersId();
        
        Task<UserModel> GetUserById(int id);
        Task UpdateUser(int id, UserModel user);
        Task DeleteUser(int id);
    }
}
