using Application.Models.ProductoModels;
using Domain.Entities;

namespace Application.Interfaces.IProducto
{
    public interface IProductoServiceQuery
    {
        Task<List<Producto>> GetProductos();

        Task<Producto> GetProductoById(int productoId);

        Task<List<Producto>> GetProductoByName(string? name, bool? sort);
    }
}
