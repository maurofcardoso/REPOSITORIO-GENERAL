using System.ComponentModel.DataAnnotations;

namespace Application.Models.ClienteModels
{
    public class ClienteRequest
    {
        [Required]
        [StringLength(10, ErrorMessage = "El maximo permitido son 10 caracteres")]
        public string dni { get; set; }

        [Required]
        [StringLength(25, ErrorMessage = "El maximo permitido son 25 caracteres")]
        public string name { get; set; }

        [Required]
        [StringLength(25, ErrorMessage = "El maximo permitido son 25 caracteres")]
        public string lastname { get; set; }

        [Required]
        [StringLength(255, ErrorMessage = "El maximo permitido son 255 caracteres")]
        public string address { get; set; }

        [Required]
        [StringLength(13, ErrorMessage = "El maximo permitido son 13 caracteres")]
        public string phoneNumber { get; set; }
    }
}
