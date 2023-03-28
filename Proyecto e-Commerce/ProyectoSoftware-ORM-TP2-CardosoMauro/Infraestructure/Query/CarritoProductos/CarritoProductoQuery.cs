using Application.Interfaces.ICarritoProducto;
using Domain.Entities;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Query.CarritoProductos
{
    public class CarritoProductoQuery : ICarritoProductoQuery
    {
        private readonly ProyectoSoftwareContext _context;

        public CarritoProductoQuery(ProyectoSoftwareContext contexto)
        {
            _context = contexto;
        }

        public async Task<List<CarritoProducto>> GetListCarritoProductos()
        {
            var carritoProducto = await _context.CarritoProductos.ToListAsync();
            if (carritoProducto == null)
            {
                return null;
            }
            return carritoProducto;
        }

        public async Task<CarritoProducto> GetCarritoProductoById(int id)
        {
            return await _context.CarritoProductos.Include(p => p.Producto).Include(c => c.Carrito).FirstOrDefaultAsync();
        }
    }
}
