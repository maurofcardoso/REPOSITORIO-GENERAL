using Domain.Entities;

namespace Aplication.Interfaces
{
    public interface IRolQuery
    {
        Rol Get(int id);
        List<Rol> GetAll();
        bool Exist(string title);
    }
}
