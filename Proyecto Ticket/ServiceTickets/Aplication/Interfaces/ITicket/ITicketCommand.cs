using Aplication.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interfaces.ITicket
{
    public interface ITicketCommand
    {
        void Create(Ticket ticket);

        void CreateTicketBody(TicketBody ticketBody);

        void CreateTicketCount(TicketCount ticketCount);

        Ticket UpdateTicketStatus(Ticket ticket, TicketStatus ticketStatus);

        Ticket UpdateTicketCategory(Ticket ticket, TicketCategory ticketCategory);

        void UpdateTicket(Ticket ticket);
    }
}
