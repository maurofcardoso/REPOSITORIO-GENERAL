using Application.Exceptions;
using Application.Interfaces.CommandAndQuery;
using Application.Interfaces.Mappers;
using Application.Interfaces.ServiceCommandAndQuery;
using Application.Models.Common;
using Application.Models.Request;
using Application.Models.Response;
using Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Application.UseCase.Users
{
    public class UserService : IServiceQueryWithUser<User>
    {
        private readonly ICommand<User> _commandUser;
        private readonly IQueryWithUser<User> _queryUser;
        private readonly IMapperDisney _mapperDisney;
        private readonly AppSettings _appSettings;

        public UserService(ICommand<User> commandUser, IQueryWithUser<User> queryUser, IMapperDisney mapperDisney, IOptions<AppSettings> appSettings)
        {
            _commandUser = commandUser;
            _queryUser = queryUser;
            _mapperDisney = mapperDisney;
            _appSettings = appSettings.Value;
        }

        public async Task<User> CreateElement(UserRequest elementRequest)
        {
            if (elementRequest == null)
            {
                throw new ItemError("Error en ingreso de datos.");
            }

            User UserAux = await this.exists(elementRequest.Email);
            if (UserAux != null)
            {
                throw new ItemError("El usuario ya existe.");
            }

            User user = _mapperDisney.UserRequestAtUser(elementRequest);

            await _commandUser.Insert(user);

            return user;
        }

        public async Task<User> DeleteElement(int elementId)
        {
            if (elementId < 1)
            {
                throw new ItemError("Error en ingreso de datos.");
            }

            User user = await this.exists(elementId);
            if (user == null)
            {
                throw new ItemDuplicate("El personaje no existe.");
            }

            await _commandUser.Remove(user);
            return user;
        }

        public async Task<User> exists(int elementId)
        {
            if (elementId < 1)
            {
                throw new ItemError("Error en ingreso de datos");
            }

            User user = await _queryUser.GetById(elementId);
            if (user == null)
            {
                return null;
            }
            return user;
        }

        public async Task<User> exists(string email)
        {
            if (email == null)
            {
                throw new ItemError("Error en ingreso de datos");
            }

            User user = await _queryUser.GetByEmail(email);
            if (user == null)
            {
                return null;
            }
            return user;
        }

        public async Task<User> GetElement(int elementId)
        {
            if (elementId < 1)
            {
                throw new ItemError("El valor ingresado es incorrecto.");
            }

            User user = await _queryUser.GetById(elementId);

            if (user == null)
            {
                throw new ItemNotFound("No hay coincidencias.");
            }

            return user;
        }

        public async Task<IEnumerable<User>> GetListElement()
        {
            return await _queryUser.GetList();
        }

        public async Task<User> GetUser(string usuarioEmail)
        {
            if (usuarioEmail == null)
            {
                throw new ItemError("El valor ingresado es incorrecto.");
            }

            User user = await _queryUser.GetByEmail(usuarioEmail);

            if (user == null)
            {
                throw new ItemNotFound("No hay coincidencias.");
            }

            return user;
        }

        public async Task<PayloadUserResponse> GetUserAuth(string email, string password)
        {
            if (email == null || password == null)
            {
                throw new ItemError("Error en ingreso de datos.");
            }

            User usuarioAuth = await _queryUser.GetUserAuth(email, password);

            if (usuarioAuth == null)
            {
                throw new ItemNotFound("No existen coincidencias.");
            }

            PayloadUserResponse payloadUserResponse = _mapperDisney.userAtPayloadNoToken(usuarioAuth);
            payloadUserResponse.Token = GetToken(usuarioAuth);

            return payloadUserResponse;
        }

        public string GetToken(User userAuth)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var llave = Encoding.ASCII.GetBytes(_appSettings.Secreto);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, userAuth.UserId.ToString()),
                        new Claim(ClaimTypes.Email, userAuth.Email),
                        new Claim(type:JwtRegisteredClaimNames.Jti, value:Guid.NewGuid().ToString()),
                        new Claim(type:JwtRegisteredClaimNames.Iat, value:DateTime.Now.ToUniversalTime().ToString()),
                    }),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(llave), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        public async Task<User> UpdateElement(UserRequest elementRequest, int elementId)
        {
            if (elementId < 1 || elementRequest == null)
            {
                throw new ItemError("Error en ingreso de datos.");
            }

            User user = await this.exists(elementId);
            if (user == null)
            {
                throw new ItemDuplicate("El personaje no existe.");
            }

            user = _mapperDisney.UserAtUserUpdate(user, elementRequest);
            await _commandUser.Update(user);
            return user;
        }
    }
}
