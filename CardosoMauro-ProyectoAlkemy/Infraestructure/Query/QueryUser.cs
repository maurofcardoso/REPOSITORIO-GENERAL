using Application.Interfaces.CommandAndQuery;
using Application.Tools;
using Domain.Entities;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Query
{
    public class QueryUser : IQueryWithUser<User>
    {
        private readonly ProyectoAlkemyContext _context;

        public QueryUser(ProyectoAlkemyContext context)
        {
            _context = context;
        }

        public async Task<User> GetById(int elementId)
        {
            if (elementId < 1)
            {
                return null;
            }
            var user = await _context.Users.Where(g => g.UserId == elementId).FirstOrDefaultAsync();
            if (user == null)
            {
                return null;
            }
            return user;
        }

        public async Task<User> GetByEmail(string userEmail)
        {
            if (userEmail == null)
            {
                return null;
            }
            var user = await _context.Users.Where(g => g.Email == userEmail).FirstOrDefaultAsync();
            if (user == null)
            {
                return null;
            }
            return user;
        }

        public async Task<IEnumerable<User>> GetList()
        {
            var user = await _context.Users.ToListAsync();
            return user;
        }

        public async Task<User> GetUserAuth(string email, string password)
        {
            var user = await _context.Users.Where(u => u.Email == email && u.Password == Encript.GetSHA256(password)).FirstOrDefaultAsync();
            if (user == null)
            {
                return null;
            }
            return user;
        }
    }
}
