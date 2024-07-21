using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Models
{
    public class AreaUpdateRequest
    {
        public bool activeArea { get; set; }
        public string nameArea { get; set; }
        public string description { get; set; }
    }
}
