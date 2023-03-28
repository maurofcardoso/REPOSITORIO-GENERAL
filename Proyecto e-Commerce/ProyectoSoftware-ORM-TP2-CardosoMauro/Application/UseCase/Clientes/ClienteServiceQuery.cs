using Application.Interfaces.ICarrito;
using Application.Interfaces.ICliente;
using Domain.Entities;

namespace Application.UseCase.Clientes
{
    public class ClienteServiceQuery : IClienteServiceQuery
    {
        private readonly IClienteQuery _query;
        private readonly ICarritoServiceQuery _carritoServiceQuery;
        public ClienteServiceQuery(IClienteQuery query, ICarritoServiceQuery carritoServiceQuery)
        {
            _query = query;
            _carritoServiceQuery = carritoServiceQuery;
        }

        public async Task<Carrito> GetCarritoActive(int clienteId)
        {
            if (clienteId < 1)
            {
                return null;
            }
            Cliente cliente = await _query.GetCliente(clienteId);
            if (cliente == null)
            {
                return null;
            }
            foreach (Carrito x in cliente.ListCarritos)
            {
                if (x.Estado)
                {
                    return await _carritoServiceQuery.GetCarrito(x.CarritoId);
                }
            }
            return null;
        }

        public async Task<Cliente> GetClienteById(int clienteId)
        {
            if (clienteId < 1)
            {
                return null;
            }
            Cliente clienteAux = await _query.GetCliente(clienteId);
            if (clienteAux == null)
            {
                return null;
            }
            return clienteAux;
        }

        public async Task<List<Cliente>> GetClientes()
        {
            List<Cliente> clientes = await _query.GetListClientes();
            return clientes;
        }
    }
}
