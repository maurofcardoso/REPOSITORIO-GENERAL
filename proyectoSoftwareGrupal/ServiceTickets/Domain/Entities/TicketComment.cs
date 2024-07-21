using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class TicketComment
    {
        public int idComment { get; set; }
        public int idTicket { get; set; }
        public int idUser { get; set; }
        public string comment { get; set; }
        public string file { get; set; }
        public DateTime dateComment { get; set; }
        public bool edited { get; set; }
        
        public Ticket ticket { get; set; }

    }
}
