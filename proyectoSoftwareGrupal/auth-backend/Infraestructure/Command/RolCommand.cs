using Aplication.Interfaces;
using Domain.Entities;
using Infraestructure.Persistence;

namespace Infraestructure.Command
{
    public class RolCommand : IRolCommand
    {
        private readonly AuthDBContext _context;
        private readonly IRolQuery _rolQuery;

        public RolCommand(AuthDBContext context, IRolQuery rolQuery)
        {
            _context = context;
            _rolQuery = rolQuery;
        }

        public async Task<Rol> Add(Rol entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(int id)
        {
            Rol entity = _rolQuery.Get(id);
            _context.Rol.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Rol entity)
        {
            throw new NotImplementedException();
        }
    }
}
