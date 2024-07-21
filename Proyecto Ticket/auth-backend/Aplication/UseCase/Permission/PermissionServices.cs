using Aplication.Exceptions;
using Aplication.Interfaces;
using Aplication.Response;
using Domain.Entities;
using Domain.Models;

namespace Aplication.UseCase
{
    public class PermissionServices : IPermissionServices
    {
        private readonly IPermissionCommand _command;
        private readonly IPermissionQuery _query;
        public PermissionServices(IPermissionCommand command, IPermissionQuery query)
        {
            _command = command;
            _query = query;
        }
        public async Task<PermissionResponse> Add(AddPermissionRequest request)
        {
            if (this.Exist(request.Title))
                throw new ItemDuplicate("Permiso existente");

            var permission = new Permission
            {
              Title = request.Title,
              Description = request.Description,
            };

            await _command.Add(permission);

            return new PermissionResponse
            {
                PermissionId = permission.PermissionId,
                Title = permission.Title,
                Description=permission.Description,
            };
        }

        public async Task Delete(int id)
        {
            await _command.Delete(id);
        }

        public PermissionResponse Get(int id)
        {        
            var result = _query.Get(id);

            if(result == null)
                throw new ItemNotFound("Permiso inexistente");

            return new PermissionResponse
            {
                PermissionId = result.PermissionId,
                Title = result.Title,
                Description = result.Description,
            };
        }

        public List<Permission> GetAll()
        {
            return _query.GetAll();
        }

        public Task Update(Permission entity)
        {
            throw new NotImplementedException();
        }
        public bool Exist(string title)
        {
            return _query.Exist(title);
        }
    }
}
