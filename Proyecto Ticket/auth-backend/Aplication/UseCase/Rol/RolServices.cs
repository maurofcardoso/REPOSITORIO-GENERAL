using Aplication.Exceptions;
using Aplication.Interfaces;
using Aplication.Response;
using Domain.Entities;
using Domain.Models;

namespace Aplication.UseCase
{
    public class RolServices : IRolServices
    {
        private readonly IRolCommand _command;
        private readonly IRolQuery _query;
        private readonly IPermissionQuery _queryPermission;

        public RolServices(IRolCommand command, IRolQuery query, IPermissionQuery queryPermission)
        {
            _command = command;
            _query = query;
            _queryPermission = queryPermission;
        }
        public async Task<RolResponse> Add(AddRolRequest request)
        {
            if (this.Exist(request.Title))
                throw new ItemDuplicate("Rol existente");

            List<RolPermission> permissions = new List<RolPermission>() { };
            List<PermissionToRol> permissionsResponse = new List<PermissionToRol>() { };


            foreach (AddPermissionToRolRequest permission in request.permissions)
            {
                var result = _queryPermission.Get(permission.PermissionId);

                if (result != null)
                {
                    var entity = new RolPermission()
                    {
                        PermissionId = permission.PermissionId,                
                    };

                    permissions.Add(entity);

                    var ptr = new PermissionToRol()
                    {
                        PermissionId = permission.PermissionId,
                        Title = result.Title,
                        Description = result.Description,                        
                    };

                    permissions.Add(entity);
                    permissionsResponse.Add(ptr);
                }
            }

            var rol = new Rol
            {
                Title = request.Title,
                Description = request.Description,
                RolPermissions = permissions,               
            };

            await _command.Add(rol);     

            return new RolResponse
            {
                RolId = rol.RolId,
                Title = rol.Title,
                Description = rol.Description,
                Permissions = permissionsResponse,
            };
        }

        public async Task Delete(int id)
        {
            await _command.Delete(id);
        }

        public RolResponse Get(int id)
        {
            var result = _query.Get(id);

            if (result == null)
                return null;

            List<PermissionToRol> permissions = new List<PermissionToRol>();

            foreach (RolPermission rp in result.RolPermissions)
            {
                var entity = new PermissionToRol()
                {
                    PermissionId = rp.PermissionId,
                    Title = rp.Permission.Title,
                    Description = rp.Permission.Description,
                };

                permissions.Add(entity);
            }

            return new RolResponse
            {
                RolId = result.RolId,
                Title = result.Title,
                Description = result.Description,
                Permissions = permissions
            };
        }

        public List<RolResponse> GetAll()
        {
            var result = _query.GetAll();

            if (result == null)
                return null;

            List<RolResponse> roles = new List<RolResponse>();

            foreach (Rol rol in result)
            {
                List<PermissionToRol> permissions = new List<PermissionToRol>();

                foreach (RolPermission rp in rol.RolPermissions)
                {
                    var ptr = new PermissionToRol()
                    {
                        PermissionId = rp.PermissionId,
                        Title = rp.Permission.Title,
                        Description = rp.Permission.Description,
                    };

                    permissions.Add(ptr);
                }

                var entity = new RolResponse()
                {
                    RolId = rol.RolId,
                    Title = rol.Title,
                    Description = rol.Description,
                    Permissions = permissions
                };

                roles.Add(entity);
            }

            return roles;
        }

        public Task Update(Rol entity)
        {
            throw new NotImplementedException();
        }

        public bool Exist(string title)
        {
            return _query.Exist(title);
        }
    }
}
