using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Response
{
    public class TicketLogResponse
    {
        public int idTicketLog { get; set; }
        public int idTicket { get; set; }
        public int idUser { get; set; }
        public DateTime dateAction { get; set; }
        public string action { get; set; }
    }
}
