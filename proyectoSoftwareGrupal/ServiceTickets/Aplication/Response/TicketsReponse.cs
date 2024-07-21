using Aplication.Response.ServiceUser;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Response
{
    public class TicketsReponse
    {
        public TicketResponse ticket { get; set; }
        public UserResponse user { get; set; }

    }
}
