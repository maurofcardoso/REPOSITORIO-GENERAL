using Application.Interfaces.ICliente;
using Domain.Entities;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Query.Clientes
{
    public class ClienteQuery : IClienteQuery
    {
        private readonly ProyectoSoftwareContext _context;

        public ClienteQuery(ProyectoSoftwareContext contexto)
        {
            _context = contexto;
        }

        public async Task<Cliente> GetCliente(int clienteId)
        {
            if (clienteId == null)
            {
                return null;
            }
            var cliente = await _context.Clientes.Where(i => i.ClienteId == clienteId).Include(l => l.ListCarritos).FirstOrDefaultAsync();
            if (cliente == null)
            {
                return null;
            }
            return cliente;
        }

        public async Task<List<Cliente>> GetListClientes()
        {
            var cliente = await _context.Clientes.Include(c => c.ListCarritos).ToListAsync();
            return cliente;
        }
    }
}
