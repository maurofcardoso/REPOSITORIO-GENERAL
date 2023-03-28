using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Models.OrdenModels
{
    public class OrdenRequest
    {
        public DateTime fecha { get; set; }

        public decimal Total { get; set; }

        public int CarritoId { get; set; }

        public int clienteId { get; set; }
    }
}
