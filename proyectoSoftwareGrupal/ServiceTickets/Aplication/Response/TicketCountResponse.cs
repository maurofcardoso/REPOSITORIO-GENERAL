using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Response
{
    public class TicketCountResponse
    {
        public int idTicketCount { get; set; }
        public int countOpen { get; set; }
        public int countApproved { get; set; }
        public int countDisapproved { get; set; }
    }
}
