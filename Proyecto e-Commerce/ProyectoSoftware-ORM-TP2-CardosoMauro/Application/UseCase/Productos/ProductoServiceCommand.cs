using Application.Interfaces.ChangeModels;
using Application.Interfaces.IProducto;
using Application.Models.ProductoModels;
using Domain.Entities;

namespace Application.UseCase.Productos
{
    public class ProductoServiceCommand : IProductoServiceCommand
    {
        private readonly IProductoCommand _command;
        private readonly IChangeModels _changeModels;

        public ProductoServiceCommand(IProductoCommand command, IChangeModels changeModels)
        {
            _command = command;
            _changeModels = changeModels;
        }

        public async Task<Producto> CreateProducto(ProductoRequest productoRequest)
        {
            if (productoRequest == null)
            {
                return null;
            }
            Producto productoAux = _changeModels.ProductoRequestChangeProducto(productoRequest);
            await _command.InsertProducto(productoAux);
            return productoAux;
        }

        public async Task<Producto> DeleteProducto(Producto producto)
        {
            if (producto == null)
            {
                return null;
            }
            await _command.RemoveProducto(producto);
            return producto;
        }

        public async Task<Producto> UpdateProducto(ProductoRequest productoRequest, int id)
        {
            if (productoRequest == null | id < 1)
            {
                return null;
            }
            Producto productoAux = _changeModels.ProductoRequestChangeProducto(productoRequest);
            productoAux.ProductoId = id;
            await _command.UpdateProducto(productoAux);
            return productoAux;
        }
    }
}
