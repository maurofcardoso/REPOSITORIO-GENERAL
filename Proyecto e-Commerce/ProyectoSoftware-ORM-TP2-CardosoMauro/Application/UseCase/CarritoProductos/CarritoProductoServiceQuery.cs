using Application.Interfaces.ICarritoProducto;
using Domain.Entities;

namespace Application.UseCase.CarritoProductos
{
    public class CarritoProductoServiceQuery : ICarritoProductoServiceQuery
    {
        private readonly ICarritoProductoQuery _query;

        public CarritoProductoServiceQuery(ICarritoProductoQuery query)
        {
            _query = query;
        }

        public async Task<CarritoProducto> GetCarritoProductoById(int carritoProductoId)
        {
            if(carritoProductoId < 1)
            {
                return null;
            }
            var carritoProducto = await _query.GetCarritoProductoById(carritoProductoId);
            return carritoProducto;
        }

        public async Task<List<CarritoProducto>> GetCarritoProductos()
        {
            List<CarritoProducto> carritoProducto = await _query.GetListCarritoProductos();
            return carritoProducto;
        }
    }
}
