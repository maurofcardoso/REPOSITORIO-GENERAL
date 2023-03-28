using Application.Interfaces.ICarritoProducto;
using Application.Models.CarritoProductoModels;
using Domain.Entities;

namespace Application.UseCase.CarritoProductos
{
    public class CarritoProductoServiceCommand : ICarritoProductoServiceCommand
    {
        private readonly ICarritoProductoCommand _command;

        public CarritoProductoServiceCommand(ICarritoProductoCommand command)
        {
            _command = command;
        }

        public async Task<CarritoProducto> CreateCarritoProducto(CarritoProductoRequest carritoProducto)
        {
            if(carritoProducto == null)
            {
                return null;
            }
            CarritoProducto carritoProductoAux = new CarritoProducto
            {
                Cantidad = carritoProducto.Cantidad,
                CarritoId = carritoProducto.CarritoId,
                ProductoId = carritoProducto.ProductoId,
            };
            await _command.InsertCarritoProducto(carritoProductoAux);
            return carritoProductoAux;
        }

        public async Task<CarritoProducto> DeleteCarritoProducto(CarritoProducto carritoProducto)
        {
            if(carritoProducto == null)
            {
                return null;
            }
            await _command.RemoveCarritoProducto(carritoProducto);
            return carritoProducto;
        }

        public async Task<CarritoProducto> UpdateCarritoProducto(CarritoProducto carritoProducto)
        {
            if (carritoProducto == null)
            {
                return null;
            }
            await _command.UpdateCarritoProducto(carritoProducto);
            return carritoProducto;
        }
    }
}
