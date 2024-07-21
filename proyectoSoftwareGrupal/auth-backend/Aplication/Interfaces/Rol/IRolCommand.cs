using Domain.Entities;

namespace Aplication.Interfaces
{
    public interface IRolCommand
    {
        Task<Rol> Add(Rol entity);
        Task Update(Rol entity);
        Task Delete(int id);
    }
}
