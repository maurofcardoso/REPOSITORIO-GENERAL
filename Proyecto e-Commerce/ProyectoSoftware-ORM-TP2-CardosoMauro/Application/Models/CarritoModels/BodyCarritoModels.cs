using System.ComponentModel.DataAnnotations;

namespace Application.Models.CarritoModels
{
    public class BodyCarritoModels
    {
        [Required]
        [Range(0, short.MaxValue, ErrorMessage = "Debe ingresar un valor de 32767 como maximo.")]
        public int clientId { get; set; }

        [Required]
        [Range(0, short.MaxValue, ErrorMessage = "Debe ingresar un valor de 32767 como maximo.")]
        public int productId { get; set; }

        [Required]
        [Range(0, short.MaxValue, ErrorMessage = "Debe ingresar un valor de 32767 como maximo.")]
        public int amount { get; set; }
    }
}
