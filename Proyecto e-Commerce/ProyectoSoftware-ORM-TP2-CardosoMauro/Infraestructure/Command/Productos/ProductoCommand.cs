using Application.Interfaces.IProducto;
using Domain.Entities;
using Infraestructure.Persistence;

namespace Infraestructure.Command.Productos
{
    public class ProductoCommand : IProductoCommand
    {
        private readonly ProyectoSoftwareContext _context;

        public ProductoCommand(ProyectoSoftwareContext contexto)
        {
            _context = contexto;
        }

        public async Task InsertProducto(Producto producto)
        {
            _context.Add(producto);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveProducto(Producto producto)
        {
            _context.Remove(producto);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProducto(Producto producto)
        {
            _context.Update(producto);
            await _context.SaveChangesAsync();
        }
    }
}
