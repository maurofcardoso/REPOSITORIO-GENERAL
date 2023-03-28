using Application.Interfaces.IOrden;
using Domain.Entities;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Query.Ordenes
{
    public class OrdenQuery : IOrdenQuery
    {
        private readonly ProyectoSoftwareContext _context;

        public OrdenQuery(ProyectoSoftwareContext contexto)
        {
            _context = contexto;
        }

        public async Task<Orden> GetOrden(Guid ordenId)
        {
            if (ordenId == Guid.Empty)
            {
                return null;
            }
            var orden = await _context.Ordenes.Include(m => m.Carrito).FirstOrDefaultAsync(x => x.OrdenId == ordenId);
            if (orden == null)
            {
                return null;
            }
            return orden;
        }

        public async Task<List<Orden>> GetListOrdenes()
        {
            var orden = await _context.Ordenes.Include(c => c.Carrito).ThenInclude(c => c.ListCarritoProductos).ToListAsync();
            if (orden == null)
            {
                return null;
            }
            return orden;
        }

        public async Task<List<Orden>> GetListOrdenByDate(DateTime date)
        {
            var orden = _context.Ordenes.Include(x => x.Carrito).Where(y => y.Fecha.Date == date).ToList();
            return orden;
        }
    }
}
