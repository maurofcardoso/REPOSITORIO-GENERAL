using Domain.Entities;

namespace Application.Interfaces.ICarritoProducto
{
    public interface ICarritoProductoServiceQuery
    {
        Task<List<CarritoProducto>> GetCarritoProductos();

        Task<CarritoProducto> GetCarritoProductoById(int carritoProductoId);
    }
}
