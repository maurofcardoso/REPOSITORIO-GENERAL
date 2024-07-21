using Aplication.Models;
using Aplication.Response;
using Aplication.Response.ServiceUser;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interfaces.ITicket
{
    public interface ITicketQuery
    {
        List<Ticket> GetAll();

        List<Ticket> GetAllByCategory(List<TicketCategory> ticketsCategory);

        Ticket GetById(int id);

        List<Ticket> GetAllCreated(int UserId);

        UserResponse GetUser(int id, string jwt);

        TicketStatus GetStatus(int StatusId);

        TicketPriority GetPriority(int PriorityId);

        TicketCategory GetCategory(int CategoryId);
    }
}
