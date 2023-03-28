using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Models.ProductoModels
{
    public class ProductoRequest
    {
        [Required]
        [StringLength(255, ErrorMessage = "El maximo permitido son 255 caracteres")]
        public string Nombre { get; set; }

        [Required]
        [StringLength(255, ErrorMessage = "El maximo permitido son 255 caracteres")]
        public string Descripcion { get; set; }

        [Required]
        [StringLength(25, ErrorMessage = "El maximo permitido son 25 caracteres")]
        public string Marca { get; set; }

        [Required]
        [StringLength(25, ErrorMessage = "El maximo permitido son 25 caracteres")]
        public string Codigo { get; set; }

        [Required]
        [Column(TypeName = "decimal(15, 2)")]
        public decimal Precio { get; set; }

        [Required]
        [StringLength(255, ErrorMessage = "El maximo permitido son 255 caracteres")]
        public string Image { get; set; }
    }
}
