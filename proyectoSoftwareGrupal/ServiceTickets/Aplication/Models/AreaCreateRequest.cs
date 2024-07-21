using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Models
{
    public class AreaCreateRequest
    {
        public string nameArea { get; set; }
        public string description { get; set; }
    }
}
