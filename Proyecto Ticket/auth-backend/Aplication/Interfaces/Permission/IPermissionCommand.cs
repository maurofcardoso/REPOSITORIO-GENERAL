using Domain.Entities;

namespace Aplication.Interfaces
{
    public interface IPermissionCommand
    {
        Task Add(Permission entity);
        Task Update(Permission entity);
        Task Delete(int id);
    }
}
