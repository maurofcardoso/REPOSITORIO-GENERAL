using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Models.ResponseCompleto
{
    public class OrdenResponseCompleto
    {
        public string Fecha { get; set; }

        [Column(TypeName = "decimal(15, 2)")]
        public decimal Total { get; set; }

        public ClienteResponseCompleto ResponseCompleto { get; set; }
    }
}
