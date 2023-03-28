using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Models.ProductoModels
{
    public class ProductoResponse
    {
        public int ProductoId { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public string Marca { get; set; }

        public string Codigo { get; set; }

        [Column(TypeName = "decimal(15, 2)")]
        public decimal Precio { get; set; }

        public string Image { get; set; }
    }
}
