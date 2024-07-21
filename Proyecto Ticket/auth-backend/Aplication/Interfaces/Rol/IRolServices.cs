using Aplication.Response;
using Domain.Entities;
using Domain.Models;

namespace Aplication.Interfaces
{
    public interface IRolServices
    {
        Task<RolResponse> Add(AddRolRequest request);
        Task Delete(int id);
        Task Update(Rol entity);
        RolResponse Get(int id);
        List<RolResponse> GetAll();
        bool Exist(string title);
    }
}
