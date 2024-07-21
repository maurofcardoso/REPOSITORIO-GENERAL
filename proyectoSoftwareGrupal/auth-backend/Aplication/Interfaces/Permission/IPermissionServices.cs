using Aplication.Response;
using Domain.Entities;
using Domain.Models;


namespace Aplication.Interfaces
{
    public interface IPermissionServices
    {
        Task<PermissionResponse> Add(AddPermissionRequest request);
        Task Delete(int id);
        Task Update(Permission entity);
        PermissionResponse Get(int id);
        List<Permission> GetAll();
        bool Exist(string title);
    }
}
