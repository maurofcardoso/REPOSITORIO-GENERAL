using System.ComponentModel.DataAnnotations;

namespace Application.Models.OrdenModels
{
    public class BodyOrdenModels
    {
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:yyy-mm-dd}")]
        public DateTime from { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyy-mm-dd}")]
        public DateTime to { get; set; }
    }
}
