using Application.Interfaces.ChangeModels;
using Application.Interfaces.ICarrito;
using Application.Interfaces.ICarritoProducto;
using Application.Interfaces.ICliente;
using Application.Interfaces.IProducto;
using Application.Models.CarritoModels;
using Application.Models.CarritoProductoModels;
using Application.Models.ResponseCompleto;
using Domain.Entities;

namespace Application.UseCase.Carritos
{
    public class CarritoServiceCommand : ICarritoServiceCommand
    {
        private readonly ICarritoCommand _command;
        private readonly IClienteServiceQuery _clienteServiceQuery;
        private readonly ICarritoProductoServiceCommand _carritoProductoServiceCommand;
        private readonly IProductoServiceQuery _productoServiceQuery;
        private readonly IChangeModels _changeModels;

        public CarritoServiceCommand(ICarritoCommand command, IClienteServiceQuery clienteServiceQuery, ICarritoProductoServiceCommand carritoProductoServiceCommand, IProductoServiceQuery productoServiceQuery, IChangeModels changeModels)
        {
            _command = command;
            _clienteServiceQuery = clienteServiceQuery;
            _carritoProductoServiceCommand = carritoProductoServiceCommand;
            _productoServiceQuery = productoServiceQuery;
            _changeModels = changeModels;
        }

        public async Task<Carrito> AddProducto(BodyCarritoModels bodyCarritoModels)
        {
            if(bodyCarritoModels == null)
            {
                return null;
            }
            Carrito carrito = await _clienteServiceQuery.GetCarritoActive(bodyCarritoModels.clientId);
            List<Producto> ListProductos = await _productoServiceQuery.GetProductos();
            if (carrito == null | ListProductos == null)
            {
                return null;
            }
            foreach (CarritoProducto x in carrito.ListCarritoProductos)
            {
                if (x.ProductoId == bodyCarritoModels.productId)
                {
                    return null;
                }
            }
            bool ok = false;
            foreach (Producto x in ListProductos)
            {
                if (x.ProductoId == bodyCarritoModels.productId)
                {
                    ok = true;
                }
            }
            if (ok)
            {
                CarritoProducto carritoProducto = await _carritoProductoServiceCommand.CreateCarritoProducto(new CarritoProductoRequest { CarritoId = carrito.CarritoId, ProductoId = bodyCarritoModels.productId, Cantidad = bodyCarritoModels.amount, });
                return carrito;
            }
            return null;
        }

        public async Task<Carrito> CreateCarrito(CarritoRequest carritoRequest)
        {
            if(carritoRequest == null)
            {
                return null;
            }
            Carrito carrito = new Carrito
            {
                CarritoId = Guid.NewGuid(),
                ClienteId = carritoRequest.ClienteId,
                Estado = true,
            };
            await _command.InsertCarrito(carrito);
            return carrito;
        }

        public async Task<Carrito> DeleteCarrito(Carrito carrito)
        {
            if(carrito == null)
            {
                return null;
            }
            await _command.RemoveCarrito(carrito);
            return carrito;
        }

        public async Task<bool> DeleteProductoOfCarrito(int clienteId, int productoId)
        {
            bool cond = false;
            if(clienteId < 1 || productoId < 1)
            {
                return cond;
            }
            Carrito carrito = await _clienteServiceQuery.GetCarritoActive(clienteId);
            if (carrito == null)
            {
                return cond;
            }
            if (carrito.ListCarritoProductos.Count == 0)
            {
                return cond;
            }
            CarritoProducto carritoProducto = null;
            foreach (CarritoProducto x in carrito.ListCarritoProductos)
            {
                if (x.ProductoId == productoId)
                {
                    carritoProducto = x;
                    cond = true;
                }
            }
            if (cond)
            {
                await _carritoProductoServiceCommand.DeleteCarritoProducto(carritoProducto);
            }
            return cond;
        }

        public async Task<Carrito> UpdateCarrito(Carrito carrito)
        {
            if (carrito == null)
            {
                return null;
            }
            await _command.UpdateCarrito(carrito);
            return carrito;
        }

        public async Task<ProductoResponseCompleto> UpdateCarritoCantidad(BodyCarritoModels bodyCarritoModels)
        {
            if (bodyCarritoModels == null)
            {
                return null;
            }
            Carrito carrito = await _clienteServiceQuery.GetCarritoActive(bodyCarritoModels.clientId);
            if (carrito == null)
            {
                return null;
            }
            List<Cliente> ListClientes = await _clienteServiceQuery.GetClientes();
            bool ok = false;
            foreach (Cliente x in ListClientes)
            {
                if (x.ClienteId == bodyCarritoModels.clientId)
                {
                    ok = true;
                }
            }
            if (!ok)
            {
                return null;
            }
            //if (carrito.ListCarritoProductos.Count == 0)
            //{
            //    return null;
            //}
            Producto producto = null;
            foreach (CarritoProducto x in carrito.ListCarritoProductos)
            {
                if (x.ProductoId == bodyCarritoModels.productId)
                {
                    x.Cantidad = bodyCarritoModels.amount;
                    producto = await _productoServiceQuery.GetProductoById(x.ProductoId);
                    await _carritoProductoServiceCommand.UpdateCarritoProducto(x);
                }
            }
            if (producto == null)
            {
                return null;
            }
            ProductoResponseCompleto productoResponseCompleto = _changeModels.ProductoResponseCompleto(producto, bodyCarritoModels.amount);
            return productoResponseCompleto;
        }
    }
}
