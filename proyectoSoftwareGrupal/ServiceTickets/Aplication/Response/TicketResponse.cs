using Aplication.Response.ServiceUser;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Response
{
    public class TicketResponse
    {
        public int idTicket { get; set; }
        public List<TicketCommentResponse> ticketComments { get; set; }
        public List<TicketLogResponse> ticketLogs { get; set; }
        public TicketStatusResponse ticketStatus { get; set; }
        public TicketPriorityResponse ticketPriority { get; set; }
        public TicketBodyResponse ticketBody { get; set; }
        public TicketCountResponse ticketCount { get; set; }
        public TicketCategoryResponse ticketCategory { get; set; }
        public UserResponse user { get; set; }
    }
}
