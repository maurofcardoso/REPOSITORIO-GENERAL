using Application.Interfaces.ICarritoProducto;
using Domain.Entities;
using Infraestructure.Persistence;

namespace Infraestructure.Command.CarritoProductos
{
    public class CarritoProductoCommand : ICarritoProductoCommand
    {
        private readonly ProyectoSoftwareContext _context;

        public CarritoProductoCommand(ProyectoSoftwareContext contexto)
        {
            _context = contexto;
        }

        public async Task InsertCarritoProducto(CarritoProducto carritoProducto)
        {
            _context.Add(carritoProducto);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveCarritoProducto(CarritoProducto carritoProducto)
        {
            _context.Remove(carritoProducto);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCarritoProducto(CarritoProducto carritoProducto)
        {
            _context.Update(carritoProducto);
            await _context.SaveChangesAsync();
        }
    }
}
