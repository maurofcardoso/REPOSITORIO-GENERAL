using Application.Models.ClienteModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Models.OrdenModels
{
    public class OrdenResponse
    {
        public ClienteResponse clienteResponse { get; set; }

        public DateTime Fecha { get; set; }

        [Column(TypeName = "decimal(15, 2)")]
        public decimal Total { get; set; }
    }
}
