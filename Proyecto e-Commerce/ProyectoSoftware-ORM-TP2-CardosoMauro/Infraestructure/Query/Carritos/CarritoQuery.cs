using Application.Interfaces.ICarrito;
using Domain.Entities;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Query.Carritos
{
    public class CarritoQuery : ICarritoQuery
    {
        private readonly ProyectoSoftwareContext _context;

        public CarritoQuery(ProyectoSoftwareContext contexto)
        {
            _context = contexto;
        }

        public async Task<Carrito> GetCarrito(Guid carritoId)
        {
            if (carritoId == Guid.Empty)
            {
                return null;
            }
            var carrito = await _context.Carritos.Where(i => i.CarritoId == carritoId).Include(l => l.ListCarritoProductos).ThenInclude(c => c.Producto).FirstOrDefaultAsync();
            if (carrito == null)
            {
                return null;
            }
            return carrito;
        }

        public async Task<List<Carrito>> GetListCarritos()
        {
            var carrito = await _context.Carritos.Include(l => l.ListCarritoProductos).ThenInclude(c => c.Producto).ToListAsync();
            return carrito;
        }
    }
}
