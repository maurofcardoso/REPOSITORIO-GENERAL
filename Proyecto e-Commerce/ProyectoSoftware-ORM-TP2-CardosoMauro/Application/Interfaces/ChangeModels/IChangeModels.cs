using Application.Models.CarritoModels;
using Application.Models.CarritoProductoModels;
using Application.Models.ClienteModels;
using Application.Models.OrdenModels;
using Application.Models.ProductoModels;
using Application.Models.ResponseCompleto;
using Domain.Entities;

namespace Application.Interfaces.ChangeModels
{
    public interface IChangeModels
    {
        Task<CarritoResponse> CarritoChangeResponse(Carrito carrito);

        Task<ClienteResponse> ClienteChangeResponse(Cliente cliente);

        Cliente ClienteRequestChangeCliente(ClienteRequest clienteRequest);

        ProductoResponseCompleto ProductoResponseCompleto(Producto producto, int cantidad);

        ProductoResponse ProductoChangeResponse(Producto producto);

        Producto ProductoRequestChangeProducto(ProductoRequest productoRequest);

        Task<CarritoProductoResponse> carritoProductoChangeCarritoProductoResonse(CarritoProducto carritoProducto);

        Task<List<CarritoResponseCompleto>> CarritoChangeCarritoResponseCompleto(Carrito carrito);

        Task<ClienteResponseCompleto> ClienteChangeResponseCompleto(Cliente cliente, Carrito carrito);

        Task<OrdenResponseCompleto> OrdenChangeResponseCompleto(Orden orden);

        Task<BalanceComplete> BalanceComplete(List<OrdenResponseCompleto> ordenResponseCompleto);
    }
}
