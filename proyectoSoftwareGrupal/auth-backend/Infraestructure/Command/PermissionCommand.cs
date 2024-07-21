using Aplication.Interfaces;
using Domain.Entities;
using Infraestructure.Persistence;

namespace Infraestructure.Command
{
    public class PermissionCommand:IPermissionCommand
    {
        private readonly AuthDBContext _context;
        private readonly IPermissionQuery _permissionQuery;

        public PermissionCommand(AuthDBContext context, IPermissionQuery permissionQuery)
        {
            _context = context;
            _permissionQuery = permissionQuery;
        }

        public async Task Add(Permission entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Permission entity = _permissionQuery.Get(id);
            _context.Permission.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public Task Update(Permission entity)
        {
            throw new NotImplementedException();
        }
    }
}
