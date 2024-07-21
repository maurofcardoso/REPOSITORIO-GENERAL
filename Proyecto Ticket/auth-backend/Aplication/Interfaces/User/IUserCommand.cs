using Domain.Entities;

namespace Aplication.Interfaces
{
    public interface IUserCommand
    {
        Task Add(User user);
        Task Update(User user);
        Task Delete(int id);
    }
}
