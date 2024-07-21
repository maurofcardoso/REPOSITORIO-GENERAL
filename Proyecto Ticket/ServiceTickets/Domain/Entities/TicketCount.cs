using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class TicketCount
    {
        public int idTicketCount { get; set; }
        public int countOpen { get; set; }
        public int countApproved { get; set; }
        public int countDisapproved { get; set; }

        public Ticket ticket { get; set; }
    }
}
