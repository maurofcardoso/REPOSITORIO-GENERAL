using Aplication.Models;
using Aplication.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interfaces.ITicket
{
    public interface ITicketService
    {
        ResponseGral Create(TicketRequest request, string jwt);
        ResponseGral GetById(int id, string jwt);
        ResponseGral GetAll(string jwt);
        ResponseGral UpdateStatus(TicketUpdateStatusRequest request, string jwt);

        ResponseGral UpdateCategory(TicketUpdateCategoryRequest request, string jwt);
        ResponseGral AddCommentToTicket(int idTicket, TicketComment ticketComment);
    }
}
