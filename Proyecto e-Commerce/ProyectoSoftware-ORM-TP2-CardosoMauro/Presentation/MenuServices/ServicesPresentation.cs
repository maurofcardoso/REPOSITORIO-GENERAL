using Application.Interfaces.ChangeModels;
using Application.Interfaces.ICarrito;
using Application.Interfaces.ICliente;
using Application.Interfaces.IOrden;
using Application.Interfaces.IProducto;
using Application.Interfaces.ServicesPresentation;
using Application.Models.CarritoModels;
using Application.Models.ClienteModels;
using Application.Models.OrdenModels;
using Application.Models.ProductoModels;
using Application.Models.ResponseCompleto;
using Domain.Entities;

namespace Presentation.MenuServices
{
    public class ServicesPresentation : IServicesPresentation
    {
        private readonly ICarritoServiceCommand _carritoServiceCommand;
        private readonly IChangeModels _changeModels;
        private readonly IOrdenServiceCommand _ordenServiceCommand;
        private readonly IClienteServiceCommand _clienteServiceCommand;
        private readonly IOrdenServiceQuery _ordenServiceQuery;
        private readonly IProductoServiceQuery _productoServiceQuery;
        private readonly IClienteServiceQuery _clienteServiceQuery;

        public ServicesPresentation(ICarritoServiceCommand carritoServiceCommand, IChangeModels changeModels, IOrdenServiceCommand ordenServiceCommand, IClienteServiceCommand clienteServiceCommand, IOrdenServiceQuery ordenServiceQuery, IProductoServiceQuery productoServiceQuery, IClienteServiceQuery clienteServiceQuery)
        {
            _carritoServiceCommand = carritoServiceCommand;
            _changeModels = changeModels;
            _ordenServiceCommand = ordenServiceCommand;
            _clienteServiceCommand = clienteServiceCommand;
            _ordenServiceQuery = ordenServiceQuery;
            _productoServiceQuery = productoServiceQuery;
            _clienteServiceQuery = clienteServiceQuery;
        }

        public async Task<CarritoResponse> EndPointAddProducto(BodyCarritoModels bodyCarritoModels)
        {
            if (bodyCarritoModels == null)
            {
                return null;
            }

            Carrito carrito = await _carritoServiceCommand.AddProducto(bodyCarritoModels);
            if (carrito == null)
            {
                return null;
            }
            CarritoResponse carritoResponse = await _changeModels.CarritoChangeResponse(carrito);
            return carritoResponse;
        }

        public async Task<BalanceComplete> EndPointBalanceOfDay(DateTime? from, DateTime? to)
        {
            List<OrdenResponseCompleto> ListOrdenResponse = new List<OrdenResponseCompleto>();
            List<Orden> ListOrden = await _ordenServiceQuery.GetListOrdenByDate( from, to);
            foreach (Orden orden in ListOrden)
            {
                OrdenResponseCompleto ordenAux = await _changeModels.OrdenChangeResponseCompleto(orden);
                ListOrdenResponse.Add(ordenAux);
            }
            BalanceComplete balanceComplete = await _changeModels.BalanceComplete(ListOrdenResponse);
            return balanceComplete;
        }

        public async Task<OrdenResponseCompleto> EndPointCreateOrden(int clientId)
        {
            if (clientId < 1)
            {
                return null;
            }
            Orden orden = await _ordenServiceCommand.CreateOrden(clientId);
            OrdenResponseCompleto ordenResponse = await _changeModels.OrdenChangeResponseCompleto(orden);
            Cliente cliente = await _clienteServiceCommand.AddCarritoActive(clientId);
            return ordenResponse;
        }

        public async Task<bool> EndPointDeleteProducto(int clienteId, int productoId)
        {
            if (clienteId < 1 | productoId < 1)
            {
                return false;
            }
            bool carrito = await _carritoServiceCommand.DeleteProductoOfCarrito(clienteId, productoId);
            return carrito;
        }

        public async Task<ClienteResponseCompleto> EndPointGetCliente(int clienteId)
        {
            if (clienteId < 1)
            {
                return null;
            }
            Cliente cliente = await _clienteServiceQuery.GetClienteById(clienteId);
            Carrito carrito = await _clienteServiceQuery.GetCarritoActive(clienteId);
            if (cliente == null)
            {
                return null;
            }
            ClienteResponseCompleto clienteResponse = await _changeModels.ClienteChangeResponseCompleto(cliente, carrito);
            return clienteResponse;
        }

        public async Task<ProductoResponse> EndPointGetProductoById(int productoId)
        {
            if (productoId < 1)
            {
                return null;
            }
            Producto producto = await _productoServiceQuery.GetProductoById(productoId);
            if (producto == null)
            {
                return null;
            }
            ProductoResponse productoResponse = _changeModels.ProductoChangeResponse(producto);
            return productoResponse;
        }

        public async Task<List<ProductoResponse>> EndPointGetProductoByName(string? name, bool? sort)
        {
            List<Producto> productos = await _productoServiceQuery.GetProductoByName(name, sort);
            List<ProductoResponse> productoResponses = new List<ProductoResponse>();
            if (productos == null)
            {
                return null;
            }
            foreach (Producto x in productos)
            {
                productoResponses.Add(_changeModels.ProductoChangeResponse(x));
            }
            return productoResponses;
        }

        public async Task<ClienteResponse> EndPointRegistrarCliente(ClienteRequest clienteRequest)
        {
            if (clienteRequest == null)
            {
                return null;
            }
            Cliente cliente = await _clienteServiceCommand.CreateCliente(clienteRequest);
            Carrito carrito = await _clienteServiceQuery.GetCarritoActive(cliente.ClienteId);
            ClienteResponse clienteResponse = await _changeModels.ClienteChangeResponse(cliente);
            return clienteResponse;
        }

        public async Task<ProductoResponseCompleto> EndPointUpdateCarrito(BodyCarritoModels bodyCarritoModels)
        {
            if (bodyCarritoModels == null)
            {
                return null;
            }
            ProductoResponseCompleto carrito = await _carritoServiceCommand.UpdateCarritoCantidad(bodyCarritoModels);
            if (carrito == null)
            {
                return null;
            }
            return carrito;
        }

        public async Task<CarritoResponse> EndPointGetByIdCarrito(int clienteId)
        {
            if (clienteId < 1)
            {
                return null;
            }
            Carrito carrito = await _clienteServiceQuery.GetCarritoActive(clienteId);
            if (carrito == null)
            {
                return null;
            }
            CarritoResponse carritoResponse = await _changeModels.CarritoChangeResponse(carrito);
            return carritoResponse;
        }
    }
}
