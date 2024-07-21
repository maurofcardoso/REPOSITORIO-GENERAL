using Aplication.Models;
using Aplication.Response;
using Domain.Entities;

namespace Aplication.Interfaces
{
    public interface IUserServices
    {
        Task<User> Add(AddUserRequest request, string jwt);
        Task Delete(int id);
        Task Update(User user);
        User Get(int id);
        List<User> GetAll();
        bool Exist(string userName);

        Task<User> Login(string userName, string password);
        UserResponse MapperUser(User result);
    }
}
