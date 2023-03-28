using Application.Interfaces.ICarrito;
using Domain.Entities;
using Infraestructure.Persistence;

namespace Infraestructure.Command.Carritos
{
    public class CarritoCommand : ICarritoCommand
    {
        private readonly ProyectoSoftwareContext _context;

        public CarritoCommand(ProyectoSoftwareContext contexto)
        {
            _context = contexto;
        }

        public async Task InsertCarrito(Carrito carrito)
        {
            _context.Add(carrito);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveCarrito(Carrito carrito)
        {
            _context.Remove(carrito);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCarrito(Carrito carrito)
        {
            _context.Update(carrito);
            await _context.SaveChangesAsync();
        }
    }
}
