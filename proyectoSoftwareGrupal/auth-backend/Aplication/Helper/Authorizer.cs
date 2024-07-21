using Aplication.Interfaces.Helpers;
using Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Security;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Aplication.Helper
{
    public class Authorizer:IAuthorizer
    {  
        public string HashPassword(string pass)
        {
            var sha = SHA256.Create();
            var asByteArray = Encoding.Default.GetBytes(pass);
            var hashedPassword = sha.ComputeHash(asByteArray);
            return Convert.ToBase64String(hashedPassword);
        }

        public string GenerateToken(IPayload payload)
        {
            var NameIdentifier = payload.UserId.ToString();
            var Name = payload.UserName;
            var Email = payload.Email;
            var Role = payload.RolId.ToString();
            var Gender = payload.Permissions;
            var areaid= payload.AreaId;
            //Generar Token:
            var claims = new[]
            {
                    new Claim(ClaimTypes.NameIdentifier, payload.UserId.ToString()),
                    new Claim(ClaimTypes.Name, payload.UserName),
                    new Claim(ClaimTypes.Email, payload.Email),
                    new Claim(ClaimTypes.Role, payload.RolId.ToString()),
                    new Claim(ClaimTypes.Gender, payload.Permissions),
                    new Claim(ClaimTypes.Actor, payload.AreaId),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Inter202211111111"));
            var credenciales = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = credenciales,
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

    }
}
