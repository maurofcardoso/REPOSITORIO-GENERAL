using Application.Interfaces.ICarrito;
using Domain.Entities;

namespace Application.UseCase.Carritos
{
    public class CarritoServiceQuery : ICarritoServiceQuery
    {
        private readonly ICarritoQuery _query;

        public CarritoServiceQuery(ICarritoQuery query)
        {
            _query = query;
        }

        public async Task<Carrito> GetCarrito(Guid carritoId)
        {
            Carrito carritoAux = await _query.GetCarrito(carritoId);
            return carritoAux;
        }

        public Task<List<Carrito>> GetCarritos()
        {
            return _query.GetListCarritos();
        }
    }
}
