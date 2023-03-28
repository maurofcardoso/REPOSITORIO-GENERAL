using Domain.Entities;

namespace Application.Interfaces.ICarrito
{
    public interface ICarritoServiceQuery
    {
        Task<List<Carrito>> GetCarritos();

        Task<Carrito> GetCarrito(Guid carritoId);
    }
}
