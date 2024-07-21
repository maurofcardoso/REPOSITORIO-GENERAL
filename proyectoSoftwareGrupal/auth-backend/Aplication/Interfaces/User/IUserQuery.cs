using Domain.Entities;

namespace Aplication.Interfaces
{
    public interface IUserQuery
    {
        User Get(int id);
        User Get(string userName);

        List<User> GetAll();
        bool Exist(string userName);

    }
}
