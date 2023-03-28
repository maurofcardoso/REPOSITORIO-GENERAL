using Application.Models.CarritoModels;
using Application.Models.ClienteModels;
using Application.Models.OrdenModels;
using Application.Models.ProductoModels;
using Application.Models.ResponseCompleto;

namespace Application.Interfaces.ServicesPresentation
{
    public interface IServicesPresentation
    {
        Task<ClienteResponseCompleto> EndPointGetCliente(int clienteId); //eliminar, solo pruebas

        Task<ClienteResponse> EndPointRegistrarCliente(ClienteRequest clienteRequest);

        //Task<List<ProductoResponse>> EndPointGetProductos();

        Task<List<ProductoResponse>> EndPointGetProductoByName(string? name, bool? sort);

        Task<ProductoResponse> EndPointGetProductoById(int productoId);

        Task<CarritoResponse> EndPointAddProducto(BodyCarritoModels bodyCarritoModels);

        Task<ProductoResponseCompleto> EndPointUpdateCarrito(BodyCarritoModels bodyCarritoModels);

        Task<bool> EndPointDeleteProducto(int clienteId, int productoId);

        Task<OrdenResponseCompleto> EndPointCreateOrden(int clientId);

        Task<BalanceComplete> EndPointBalanceOfDay(DateTime? from, DateTime? to);

        Task<CarritoResponse> EndPointGetByIdCarrito(int clientId);
    }
}
