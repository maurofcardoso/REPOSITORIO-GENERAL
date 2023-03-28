using Application.Interfaces.IProducto;
using Domain.Entities;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Query.Productos
{
    public class ProductoQuery : IProductoQuery
    {
        private readonly ProyectoSoftwareContext _context;

        public ProductoQuery(ProyectoSoftwareContext contexto)
        {
            _context = contexto;
        }

        public async Task<Producto> GetProducto(int productoId)
        {
            if (productoId < 1)
            {
                return null;
            }
            var producto = await _context.Productos.Where(i => i.ProductoId == productoId).Include(l => l.ListCarritoProductos).ThenInclude(c => c.Carrito).FirstOrDefaultAsync();
            return producto;
        }

        public async Task<List<Producto>> GetListProductos()
        {
            var producto = await _context.Productos.Include(l => l.ListCarritoProductos).ThenInclude(c => c.Carrito).ToListAsync();
            return producto;
        }
    }
}
