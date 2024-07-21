using Domain.Entities;

namespace Aplication.Interfaces
{
    public interface IPermissionQuery
    {
        Permission Get(int id);
        List<Permission> GetAll(); 
        bool Exist(string title);
    }
}
