using Application.Interfaces.IOrden;
using Domain.Entities;

namespace Application.UseCase.Ordenes
{
    public class OrdenServiceQuery : IOrdenServiceQuery
    {
        private readonly IOrdenQuery _query;

        public OrdenServiceQuery(IOrdenQuery query)
        {
            _query = query;
        }

        public async Task<List<Orden>> GetListOrdenByDate(DateTime? desde, DateTime? hasta)
        {
            List<Orden> ListSeleccion = new List<Orden>();
            List<Orden> ListOrden = await _query.GetListOrdenes();
            var selection = from orden in ListOrden
                            where orden.Fecha.Date >= ((DateTime)desde).Date && orden.Fecha <= ((DateTime)hasta).Date.AddDays(1)
                            select orden;
            if (desde == null && hasta == null)
            {
                return ListOrden;
            }
            if (desde == null && hasta != null)
            {
                selection = from orden in ListOrden
                                where orden.Fecha <= ((DateTime)hasta).Date.AddDays(1)
                                select orden;
            }
            if (desde != null && hasta == null)
            {
                selection = from orden in ListOrden
                            where orden.Fecha.Date >= ((DateTime)desde).Date 
                            select orden;
            }
            foreach (Orden orden in selection)
            {
                ListSeleccion.Add(orden);
            }
            return ListSeleccion;
        }

        public async Task<Orden> GetOrdenById(Guid ordenId)
        {
            if (ordenId == Guid.Empty)
            {
                return null;
            }
            Orden orden = await _query.GetOrden(ordenId);
            return orden;
        }

        public async Task<List<Orden>> GetOrdenes()
        {
            var ordenes = await _query.GetListOrdenes();
            return ordenes;
        } 
    }
}
