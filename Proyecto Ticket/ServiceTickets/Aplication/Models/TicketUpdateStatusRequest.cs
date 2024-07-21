using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Models
{
    public class TicketUpdateStatusRequest
    {
        public int idTicket { get; set; }
        public int idUser { get; set; }
        public int StatusId { get; set; }
    }
}
