using Application.Interfaces.ChangeModels;
using Application.Interfaces.ICarrito;
using Application.Interfaces.ICliente;
using Application.Interfaces.IProducto;
using Application.Models.CarritoModels;
using Application.Models.CarritoProductoModels;
using Application.Models.ClienteModels;
using Application.Models.ProductoModels;
using Application.Models.ResponseCompleto;
using Domain.Entities;

namespace Application.UseCase.ChangeModels
{
    public class ChangeModels : IChangeModels
    {
        private readonly IProductoServiceQuery _productoServiceQuery;
        private readonly IClienteServiceQuery _clienteServiceQuery;
        private readonly ICarritoServiceQuery _carritoServiceQuery;

        public ChangeModels(IProductoServiceQuery productoServiceQuery, IClienteServiceQuery clienteServiceQuery, ICarritoServiceQuery carritoServiceQuery)
        {
            _productoServiceQuery = productoServiceQuery;
            _clienteServiceQuery = clienteServiceQuery;
            _carritoServiceQuery = carritoServiceQuery;
        }

        public async Task<CarritoResponse> CarritoChangeResponse(Carrito carrito)
        {
            if(carrito == null)
            {
                return null;
            }
            List<CarritoProductoResponse> ListCarritoPorductoResponse = new List<CarritoProductoResponse>();
            foreach (CarritoProducto x in carrito.ListCarritoProductos)
            {
                ListCarritoPorductoResponse.Add(await this.carritoProductoChangeCarritoProductoResonse(x));
            }
            var carritoResponse = new CarritoResponse
            {
                ListCarritoProductoResponse = ListCarritoPorductoResponse,
            };
            return carritoResponse;
        } 

        public async Task<ClienteResponse> ClienteChangeResponse(Cliente cliente)
        {
            if (cliente == null)
            {
                return null;
            }
            List<CarritoResponse> ListCarritoResponse = new List<CarritoResponse>();
            foreach (Carrito x in cliente.ListCarritos)
            {
                ListCarritoResponse.Add(await this.CarritoChangeResponse(x));
            }
            var clienteResponse = new ClienteResponse
            {
                dni = cliente.DNI,
                name = cliente.Nombre,
                lastname = cliente.Apellido,
                address = cliente.Direccion,
                phoneNumber = cliente.Telefono,
            };
            return clienteResponse;
        }

        public Cliente ClienteRequestChangeCliente(ClienteRequest clienteRequest)
        {
            if (clienteRequest == null)
            {
                return null;
            }
            var cliente = new Cliente
            {
                DNI = clienteRequest.dni,
                Nombre = clienteRequest.name,
                Apellido = clienteRequest.lastname,
                Direccion = clienteRequest.address,
                Telefono = clienteRequest.phoneNumber,
            };
            return cliente;
        }

        public ProductoResponseCompleto ProductoResponseCompleto(Producto producto, int cantidad)
        {
            if (producto == null)
            {
                return null;
            }
            var productoResponse = new ProductoResponseCompleto
            {
                ProductoId = producto.ProductoId,
                Cantidad = cantidad,
                Nombre = producto.Nombre,
                Descripcion = producto.Descripcion,
                Marca = producto.Marca,
                Codigo = producto.Codigo,
                Precio = producto.Precio,
                Image = producto.Image,
            };
            return productoResponse;
        }

        public ProductoResponse ProductoChangeResponse(Producto producto)
        {
            if (producto == null)
            {
                return null;
            }
            var productoResponse = new ProductoResponse
            {
                ProductoId = producto.ProductoId,
                Nombre = producto.Nombre,
                Descripcion = producto.Descripcion,
                Marca = producto.Marca,
                Codigo = producto.Codigo,
                Precio = producto.Precio,
                Image = producto.Image,
            };
            return productoResponse;
        }

        public Producto ProductoRequestChangeProducto(ProductoRequest productoRequest)
        {
            if (productoRequest == null)
            {
                return null;
            }
            var producto = new Producto
            {
                Nombre = productoRequest.Nombre,
                Descripcion = productoRequest.Descripcion,
                Marca = productoRequest.Marca,
                Codigo = productoRequest.Codigo,
                Precio = productoRequest.Precio,
                Image = productoRequest.Image
            };
            return producto;
        }

        public async Task<CarritoProductoResponse> carritoProductoChangeCarritoProductoResonse(CarritoProducto carritoProducto)
        {
            if (carritoProducto == null)
            {
                return null;
            }
            Producto producto = await _productoServiceQuery.GetProductoById(carritoProducto.ProductoId);
            var carritoProductoResponse = new CarritoProductoResponse
            {
                ProductoId = carritoProducto.ProductoId,
                Cantidad = carritoProducto.Cantidad,
                Nombre = producto.Nombre,
                Descripcion = producto.Descripcion,
                Marca = producto.Marca,
                Codigo = producto.Codigo,
                Precio = producto.Precio,
                Image = producto.Image,
            };
            return carritoProductoResponse;
        }

        public async Task<List<CarritoResponseCompleto>> CarritoChangeCarritoResponseCompleto(Carrito carrito)
        {
            CarritoResponseCompleto carritoResponseCompleto = null;
            List<CarritoResponseCompleto> carritoProductos = new List<CarritoResponseCompleto>();
            if (carrito != null && carrito.ListCarritoProductos.Count != 0)
            {
                foreach (CarritoProducto x in carrito.ListCarritoProductos)
                {
                    Producto producto = await _productoServiceQuery.GetProductoById((int)x.ProductoId);
                    carritoResponseCompleto = new CarritoResponseCompleto
                    {
                        ProductoId = x.ProductoId,
                        Nombre = producto.Nombre,
                        Descripcion = producto.Descripcion,
                        Marca = producto.Marca,
                        Codigo = producto.Codigo,
                        Precio = producto.Precio,
                        Image = producto.Image,
                        cantidad = x.Cantidad,
                    };
                    carritoProductos.Add(carritoResponseCompleto);
                }
                return carritoProductos;
            }
            else
            {
                if (carrito != null)
                {
                    return null;
                }
                else
                {
                    return carritoProductos;
                }
            }
            return null;
        }

        public async Task<ClienteResponseCompleto> ClienteChangeResponseCompleto(Cliente cliente, Carrito carrito)
        {
            List<CarritoResponseCompleto> carritoResponseCompleto = await this.CarritoChangeCarritoResponseCompleto(carrito);
            ClienteResponseCompleto responseCompleto = new ClienteResponseCompleto
            {
                dni = cliente.DNI,
                name = cliente.Nombre,
                lastname = cliente.Apellido,
                address = cliente.Direccion,
                phoneNumber = cliente.Telefono,
                ListCarritos = carritoResponseCompleto,
            };
            return responseCompleto;
        }

        public async Task<OrdenResponseCompleto> OrdenChangeResponseCompleto(Orden orden)
        {
            if (orden == null)
            {
                return null;
            }
            Carrito carrito = await _carritoServiceQuery.GetCarrito(orden.CarritoId);
            Cliente cliente = await _clienteServiceQuery.GetClienteById(carrito.ClienteId);
            OrdenResponseCompleto responseOrdenCompleto = new OrdenResponseCompleto
            {
                Fecha = orden.Fecha.ToShortDateString(),
                Total = orden.Total,
                ResponseCompleto = await this.ClienteChangeResponseCompleto(cliente, carrito)
            };
            return responseOrdenCompleto;
        }

        public async Task<BalanceComplete> BalanceComplete (List<OrdenResponseCompleto> ordenResponseCompleto)
        {
            if (ordenResponseCompleto.Count == 0)
            {
                return null;
            }
            decimal cont = 0;
            var balanceComplete = new BalanceComplete
            {
                CantidadVentas = ordenResponseCompleto.Count,
            };
            foreach (OrdenResponseCompleto x in ordenResponseCompleto)
            {
                cont += x.Total;
                balanceComplete.ListOrdenResponseCompleto.Add(x);
            }
            balanceComplete.RecaudationDay = cont;
            return balanceComplete;
        } 
    }
}
