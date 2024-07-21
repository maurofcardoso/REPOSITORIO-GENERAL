using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Response
{
    public class TicketBodyResponse
    {
        public int idTicketBody { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string file { get; set; }
    }
}
