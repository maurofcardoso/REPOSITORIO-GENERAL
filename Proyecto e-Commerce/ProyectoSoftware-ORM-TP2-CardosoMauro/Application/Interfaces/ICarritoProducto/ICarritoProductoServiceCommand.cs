using Application.Models.CarritoProductoModels;
using Domain.Entities;

namespace Application.Interfaces.ICarritoProducto
{
    public interface ICarritoProductoServiceCommand
    {
        Task<CarritoProducto> CreateCarritoProducto(CarritoProductoRequest carritoProducto);

        Task<CarritoProducto> DeleteCarritoProducto(CarritoProducto carritoProducto);

        Task<CarritoProducto> UpdateCarritoProducto(CarritoProducto carritoProducto);
    }
}
