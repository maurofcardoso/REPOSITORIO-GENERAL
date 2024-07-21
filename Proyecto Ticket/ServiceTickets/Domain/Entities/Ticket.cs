using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Ticket
    {
        public int idTicket { get; set; }
        public int idUser { get; set; }
        public int idStatus { get; set; }
        public int idPriority { get; set; }
        public int idTicketCount { get; set; }
        public int idTicketCategory { get; set; }
        public int idTicketBody { get; set; }


        public List<TicketComment> ticketComments { get; set; }
        public List<TicketLog> ticketLogs { get; set; }
        public TicketStatus ticketStatus { get; set; }
        public TicketPriority ticketPriority { get; set; }
        public TicketBody ticketBody { get; set; }
        public TicketCount ticketCount { get; set; }
        public TicketCategory ticketCategory { get; set; }
    }
}
