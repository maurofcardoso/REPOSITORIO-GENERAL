using Aplication.Interfaces;
using Domain.Entities;
using Infraestructure.Persistence;

namespace Infraestructure.Querys
{
    public class PermissionQuerys:IPermissionQuery
    {
        private readonly AuthDBContext _context;
        public PermissionQuerys(AuthDBContext context)
        {
            _context = context;
        }
        public Permission Get(int id)
        {           
            return _context.Permission.FirstOrDefault(t => t.PermissionId == id); ;
        }

        public List<Permission> GetAll()
        {
            return  _context.Permission.ToList();
        }
        public bool Exist(string title)
        {
            return _context.Permission.Any(p => p.Title == title);
        }
    }
}
