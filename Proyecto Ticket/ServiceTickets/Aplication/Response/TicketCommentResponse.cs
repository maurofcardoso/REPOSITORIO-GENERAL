using Aplication.Response.ServiceUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Response
{
    public class TicketCommentResponse
    {
        public int idComment { get; set; }
        public int idUser { get; set; }
        public int idTicket { get; set; }
        public string comment { get; set; }
        public string file { get; set; }
        public DateTime dateComment { get; set; }
    }
}
