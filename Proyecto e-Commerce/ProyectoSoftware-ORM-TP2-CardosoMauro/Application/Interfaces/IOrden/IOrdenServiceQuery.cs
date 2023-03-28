using Domain.Entities;

namespace Application.Interfaces.IOrden
{
    public interface IOrdenServiceQuery
    {
        Task<List<Orden>> GetOrdenes();

        Task<Orden> GetOrdenById(Guid ordenId);
        
        Task<List<Orden>> GetListOrdenByDate(DateTime? from, DateTime? to);
    }
}
