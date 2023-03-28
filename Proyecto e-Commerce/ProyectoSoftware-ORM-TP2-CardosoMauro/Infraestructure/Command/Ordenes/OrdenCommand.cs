using Application.Interfaces.IOrden;
using Domain.Entities;
using Infraestructure.Persistence;

namespace Infraestructure.Command.Ordenes
{
    public class OrdenCommand : IOrdenCommand
    {
        private readonly ProyectoSoftwareContext _context;

        public OrdenCommand(ProyectoSoftwareContext contexto)
        {
            _context = contexto;
        }

        public async Task InsertOrden(Orden orden)
        {
            _context.Add(orden);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveOrden(Orden orden)
        {
            _context.Remove(orden);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateOrden(Orden orden)
        {
            _context.Update(orden);
            await _context.SaveChangesAsync();
        }
    }
}
