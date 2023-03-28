using Application.Models.CarritoModels;
using Application.Models.ResponseCompleto;
using Domain.Entities;

namespace Application.Interfaces.ICarrito
{
    public interface ICarritoServiceCommand
    {
        Task<Carrito> CreateCarrito(CarritoRequest carritoRequest);

        Task<Carrito> UpdateCarrito(Carrito carrito);

        Task<Carrito> DeleteCarrito(Carrito carrito);

        Task<Carrito> AddProducto(BodyCarritoModels bodyCarritoModels);

        Task<bool> DeleteProductoOfCarrito(int clienteId, int productoId);

        Task<ProductoResponseCompleto> UpdateCarritoCantidad(BodyCarritoModels bodyCarritoModels);
    }
}
