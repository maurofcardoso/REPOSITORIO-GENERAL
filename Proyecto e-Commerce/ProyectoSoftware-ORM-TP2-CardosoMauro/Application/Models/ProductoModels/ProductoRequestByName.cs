using System.ComponentModel.DataAnnotations;

namespace Application.Models.ProductoModels
{
    public class ProductoRequestByName
    {
        [Required]
        [StringLength(255, ErrorMessage = "El maximo permitido son 255 caracteres")]
        public string name { get; set; }

        [Required]
        public bool sort { get; set; }
    }
}
