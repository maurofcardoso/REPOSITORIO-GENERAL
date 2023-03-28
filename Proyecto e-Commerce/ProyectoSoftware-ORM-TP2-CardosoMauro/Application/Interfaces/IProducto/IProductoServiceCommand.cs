using Application.Models.ProductoModels;
using Domain.Entities;

namespace Application.Interfaces.IProducto
{
    public interface IProductoServiceCommand
    {
        Task<Producto> CreateProducto(ProductoRequest productoRequest);

        Task<Producto> DeleteProducto(Producto producto);

        Task<Producto> UpdateProducto(ProductoRequest productoRequest, int id);
    }
}
