using Aplication.Exceptions;
using Aplication.Helper;
using Aplication.Interfaces;
using Aplication.Interfaces.Helpers;
using Aplication.Models;
using Aplication.Response;
using Domain.Entities;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserServices _userServices;
        private readonly IAuthorizer _authorizer;


        public UsersController(IUserServices userServices, IAuthorizer authorizer)
        {
            _userServices = userServices;
            _authorizer = authorizer;
        }

        [EnableCors("Policy")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            List<User> users = _userServices.GetAll();
            IEnumerable<UserResponse> usersResponse = users.Select(user => _userServices.MapperUser(user));

            return new JsonResult(usersResponse);
        }

        [EnableCors("Policy")]
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Get(int id)
        {
            var result = _userServices.Get(id);

            if (result == null)
            {
                ErrorResponse error = new ErrorResponse()
                {
                    Status = 404,
                    Title = "Usuario inexistente",
                    Message = "No existe un usuario asociado al ID " + id,
                    Date = DateTime.Now.ToString(),
                    Path = "api/Users/" + id
                };

                return NotFound(error);
            }
                      
            return new JsonResult(_userServices.MapperUser(result));
        }

        [EnableCors("Policy")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> Add(AddUserRequest request)
        {
            if (request == null)
                return NotFound();

            try
            {
                string jwt = Request.Headers["Authorization"];
                var result = await _userServices.Add(request, jwt);

                AddUserResponse user = new AddUserResponse
                {
                    UserId = result.UserId,
                    UserName = result.UserName,
                    FirstName = result.FirstName,
                    LastName = result.LastName,
                    Rol = result.Rol.Title,
                    AreaId = result.AreaId
                };

                return new JsonResult(user) { StatusCode = 201 };
            }
            catch (ItemDuplicate)
            {
                ErrorResponse error = new ErrorResponse()
                {
                    Status = 400,
                    Title = "Usuario Duplicado",
                    Message = "Ya existe un usuario con el mismo nombre de usuario.",
                    Date = DateTime.Now.ToString(),
                    Path = "api/Users"
                };

                return BadRequest(error);
            }          
            catch (ItemNotFound)
            {
                ErrorResponse error = new ErrorResponse()
                {
                    Status = 404,
                    Title = "Rol inexistente",
                    Message = "No existe el rol asociado al id " + request.RolId,
                    Date = DateTime.Now.ToString(),
                    Path = "api/Users"
                };
                return NotFound(error);
            }
            catch (AreaNotFound)
            {
                ErrorResponse error = new ErrorResponse()
                {
                    Status = 404,
                    Title = "Area inexistente",
                    Message = "No existe el Area asociada al id " + request.AreaId,
                    Date = DateTime.Now.ToString(),
                    Path = "api/Users"
                };
                return NotFound(error);
            }
        }

        [EnableCors("Policy")]
        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            if (request == null)
                return Unauthorized();

            try
            {
                var result = await _userServices.Login(request.UserName, request.Password);

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
                foreach(RolPermission rolPermission in result.Rol.RolPermissions)
                {
                    permissionsString += rolPermission.PermissionId+",";
                }
                permissionsString = permissionsString.TrimEnd(',');

                string token = _authorizer.GenerateToken(new Payload
                {
                    UserId = result.UserId,
                    UserName = result.UserName,
                    Email = result.Email,
                    RolId = result.Rol.RolId,
                    Permissions = permissionsString,
                    AreaId = result.AreaId.ToString()
                });
                
                LoginUserResponse user = new LoginUserResponse
                {
                    UserId = result.UserId,
                    UserName = result.UserName,
                    FirstName = result.FirstName,
                    LastName = result.LastName,
                    ActiveUser = result.ActiveUser,
                    Email = result.Email,
                    Rol = rolResponse,
                    AreaId = result.AreaId,
                    Token = token
                };

                return new JsonResult(user) { StatusCode = 200 };
            }
            catch (LoginError)
            {
                return Unauthorized("Usuario o contraseña invalidos");               
            }
        }     
    }
}
