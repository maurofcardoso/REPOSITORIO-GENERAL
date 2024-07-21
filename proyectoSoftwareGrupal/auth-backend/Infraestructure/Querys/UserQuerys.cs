using Aplication.Interfaces;
using Domain.Entities;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Querys
{
    public class UserQuerys : IUserQuery
    {
        private readonly AuthDBContext _context;

        public UserQuerys(AuthDBContext context)
        {
            _context = context;
        }

        public User Get(int id)
        {
            return _context.User.Include(u=> u.Rol).ThenInclude(u => u.RolPermissions).ThenInclude(u => u.Permission).FirstOrDefault(t => t.UserId == id);
        }
        public User Get(string userName)
        {
            return _context.User.Include(u => u.Rol).ThenInclude(u => u.RolPermissions).ThenInclude(u => u.Permission).FirstOrDefault(t => t.UserName == userName);
        }

        public List<User> GetAll()
        {
            return _context.User.Include(u => u.Rol).ThenInclude(u => u.RolPermissions).ThenInclude(u => u.Permission).ToList();
        }

        public bool Exist(string userName)
        {
            return _context.User.Any(p => p.UserName == userName);
        }
    }
}
