using Application.Interfaces.ChangeModels;
using Application.Interfaces.ICarrito;
using Application.Interfaces.ICliente;
using Application.Models.CarritoModels;
using Application.Models.ClienteModels;
using Domain.Entities;

namespace Application.UseCase.Clientes
{
    public class ClienteServiceCommand : IClienteServiceCommand
    {
        private readonly IClienteCommand _command;
        private readonly IClienteServiceQuery _clienteServiceQuery;
        private readonly ICarritoServiceCommand _carritoServiceCommand;
        private readonly IChangeModels _changeModels;

        public ClienteServiceCommand(IChangeModels changeModels, IClienteCommand command, ICarritoServiceCommand carritoServiceCommand, IClienteServiceQuery clienteServiceQuery, IClienteQuery query)
        {
            _changeModels = changeModels;
            _command = command;
            _carritoServiceCommand = carritoServiceCommand;
            _clienteServiceQuery = clienteServiceQuery;
        }

        public async Task<Cliente> AddCarritoActive(int clienteId)
        {
            if(clienteId < 1)
            {
                return null;
            }
            List<Cliente> ListClientes = await _clienteServiceQuery.GetClientes();
            bool ok = false;
            foreach (Cliente x in ListClientes)
            {
                if (x.ClienteId == clienteId)
                {
                    ok = true; 
                }
            }
            if (!ok)
            {
                return null;
            }
            Cliente clienteAux = await _clienteServiceQuery.GetClienteById(clienteId);
            Carrito carritoActive = await _clienteServiceQuery.GetCarritoActive(clienteId);
            carritoActive.Estado = false;
            await _carritoServiceCommand.UpdateCarrito(carritoActive);
            clienteAux.ListCarritos.Add(await _carritoServiceCommand.CreateCarrito(new CarritoRequest { ClienteId = clienteAux.ClienteId}));
            await _command.UpdateCliente(clienteAux);
            return clienteAux;
        }

        public async Task<Cliente> CreateCliente(ClienteRequest clienteRequest)
        {
            Cliente clienteAux = _changeModels.ClienteRequestChangeCliente(clienteRequest);
            await _command.InsertCliente(clienteAux);
            clienteAux.ListCarritos.Add(await _carritoServiceCommand.CreateCarrito(new CarritoRequest { ClienteId = clienteAux.ClienteId}));
            return clienteAux;
        }

        public async Task<Cliente> DeleteCliente(Cliente cliente)
        {
            if (cliente == null)
            {
                return null;
            }
            await _command.RemoveCliente(cliente);
            return cliente;
        }

        public async Task<Cliente> UpdateCliente(ClienteRequest clienteRequest, int clienteId)
        {
            if (clienteRequest == null | clienteId < 1)
            {
                return null;
            }
            Cliente cliente = _changeModels.ClienteRequestChangeCliente(clienteRequest);
            cliente.ClienteId = clienteId;
            await _command.UpdateCliente(cliente);
            return cliente;
        }
    }
}
