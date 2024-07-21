using Aplication.Exceptions;
using Aplication.Helper;
using Aplication.Interfaces;
using Aplication.Interfaces.Area;
using Aplication.Interfaces.Helpers;
using Aplication.Models;
using Aplication.Response;
using Domain.Entities;

namespace Aplication.UseCase
{
    public class UserServices : IUserServices
    {
        private readonly IUserCommand _command;
        private readonly IUserQuery _query;
        private readonly IRolQuery _rolQuery;
        private readonly IAreaQuery _areaQuery;
        private readonly IAuthorizer _authorizer;


        public UserServices(IUserCommand command, IUserQuery query, IRolQuery rolQuery, IAreaQuery areaQuery, IAuthorizer authorizer)
        {
            _command = command;
            _query = query;
            _rolQuery = rolQuery;
            _areaQuery = areaQuery;
            _authorizer = authorizer;
        }

        public async Task<User> Add(AddUserRequest request, string jwt)
        {       
            if (this.Exist(request.UserName))
                throw new ItemDuplicate("Usuario Existente");

            var rol = _rolQuery.Get(request.RolId);

            if (rol == null)
                throw new ItemNotFound("Rol inexistente");

            if(!_areaQuery.Exists(request.AreaId, jwt))
            {
                throw new AreaNotFound("Area inexistente");
            }

            var user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                DNI = request.DNI,
                Phone = request.Phone,
                UserName = request.UserName,
                RolId = request.RolId,
                AreaId = request.AreaId,
                Rol = rol,
                ActiveUser = true,
                Password = _authorizer.HashPassword("Inter7/")
            };

            await _command.Add(user);
            return user;
        }

        public async Task<User> Login(string userName, string password)
        {
            if (!this.Exist(userName))
                throw new LoginError("Usuario o contraseña erroneos");

            User user = _query.Get(userName);

            var passHashed = _authorizer.HashPassword(password);

            if(!user.Password.Equals(passHashed))
                throw new LoginError("Usuario o contraseña erroneos");

            return user;
        }

        public async Task Delete(int id)
        {
            await _command.Delete(id);
        }  

        public User Get(int id)
        {
            return _query.Get(id);
        }

        public List<User> GetAll()
        {
            return _query.GetAll();
        }

        public bool Exist(string userName)
        {
            return _query.Exist(userName);
        }

        public Task Update(User user)
        {
            throw new NotImplementedException();
        }

        public UserResponse MapperUser(User result)
        {
            List<PermissionToRol> permissions = new List<PermissionToRol>();

            if (result.Rol.RolPermissions != null)
                foreach (RolPermission rp in result.Rol.RolPermissions)
                {
                    var entity = new PermissionToRol()
                    {
                        PermissionId = rp.PermissionId,
                        Title = rp.Permission.Title,
                        Description = rp.Permission.Description,
                    };
                    permissions.Add(entity);
                }

            var rolResponse = new RolResponse
            {
                RolId = result.Rol.RolId,
                Title = result.Rol.Title,
                Description = result.Rol.Description,
                Permissions = permissions
            };

            string permissionsString = "";
            foreach (RolPermission rolPermission in result.Rol.RolPermissions)
            {
                permissionsString += rolPermission.PermissionId + ",";
            }
            permissionsString = permissionsString.TrimEnd(',');

            string token = _authorizer.GenerateToken(new Payload
            {
                Email = result.Email,
                RolId = result.Rol.RolId,
                UserId = result.UserId,
                UserName = result.UserName,
                Permissions = permissionsString,
                AreaId = result.AreaId.ToString()
            });

            UserResponse user = new UserResponse
            {
                UserId = result.UserId,
                UserName = result.UserName,
                FirstName = result.FirstName,
                LastName = result.LastName,
                ActiveUser = result.ActiveUser,
                Email = result.Email,
                Rol = rolResponse,
                AreaId = result.AreaId
            };
            return user;
        }
    }
}
