using Aplication.Interfaces;
using Domain.Entities;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Querys
{
    public class RolQuerys:IRolQuery
    {
        private readonly AuthDBContext _context;
        public RolQuerys(AuthDBContext context)
        {
            _context = context;
        }
        public Rol Get(int id)
        {
            return _context.Rol
                .Include(r => r.RolPermissions)
                .ThenInclude(rp => rp.Permission)
                .FirstOrDefault(t => t.RolId == id);
        }

        public List<Rol> GetAll()
        {
            var h = _context.Rol
                .Include(r => r.RolPermissions)
                .ThenInclude(rp => rp.Permission)
                .ToList();
            return h;
        }

        public bool Exist(string title)
        {
            return _context.Rol.Any(p => p.Title == title);
        }
    }
}
