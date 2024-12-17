using Domain.Models;
using Infrastructore.Responses;
namespace Infrastructore.Interfaces;

public interface IUserService
{
    public Task<Response<List<User>>> GetUsers();
    public Task<Response<bool>> AddUser(User user);
    public Task<Response<bool>> DeleteUser(int id);
    public Task<Response<bool>> UpdateUser(User user);
    public Task<Response<User>> GetUserById(int id);
}