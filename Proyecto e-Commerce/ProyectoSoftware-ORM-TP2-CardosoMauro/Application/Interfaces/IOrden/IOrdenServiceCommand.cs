using Application.Models.OrdenModels;
using Domain.Entities;

namespace Application.Interfaces.IOrden
{
    public interface IOrdenServiceCommand
    {
        Task<Orden> CreateOrden(int ClienteId);

        Task<Orden> DeleteOrden(Orden orden);

        Task<Orden> UpdateOrden(OrdenRequest orden, Guid ordenId);

        decimal OrdenGetTotals(Carrito carrito);
    }
}
