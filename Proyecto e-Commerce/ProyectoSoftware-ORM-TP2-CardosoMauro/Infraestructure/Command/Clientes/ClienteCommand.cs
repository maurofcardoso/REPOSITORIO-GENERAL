using Application.Interfaces.ICliente;
using Domain.Entities;
using Infraestructure.Persistence;

namespace Infraestructure.Command.Clientes
{
    public class ClienteCommand : IClienteCommand
    {
        private readonly ProyectoSoftwareContext _context;

        public ClienteCommand(ProyectoSoftwareContext contexto)
        {
            _context = contexto;
        }

        public async Task InsertCliente(Cliente cliente)
        {
            _context.Add(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveCliente(Cliente cliente)
        {
            _context.Remove(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCliente(Cliente cliente)
        {
            _context.Update(cliente);
            await _context.SaveChangesAsync();
        }
    }
}
