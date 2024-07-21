using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Models
{
    public class TicketCommentRequest
    {
        public int idTicket { get; set; }
        public string comment { get; set; }
        public string file { get; set; }
    }
}
