using Aplication.Interfaces;
using Aplication.Models;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplication.Interfaces.ITicket;

namespace Infrastructure.Command
{
    public class TicketCommand : ITicketCommand
    {
        private readonly AppDbContext _context;

        public TicketCommand(AppDbContext context)
        {
            _context = context;
        }

        public void Create(Ticket ticket)
        {
            _context.Add(ticket);
            _context.SaveChanges();
        }

        public void CreateTicketBody(TicketBody ticketBody)
        {
            _context.Add(ticketBody);
            _context.SaveChanges();
        }

        public void CreateTicketCount(TicketCount ticketCount)
        {
            _context.Add(ticketCount);
            _context.SaveChanges();
        }

        public Ticket UpdateTicketStatus(Ticket ticket, TicketStatus ticketStatus)
        {
            ticket.idStatus = ticketStatus.idTicketStatus;
            _context.SaveChanges();
            return ticket;
        }

        public Ticket UpdateTicketCategory(Ticket ticket, TicketCategory ticketCategory)
        {
            ticket.idTicketCategory = ticketCategory.idTicketCategory;
            _context.SaveChanges();
            return ticket;
        }

        public void UpdateTicket(Ticket ticket)
        {
            _context.Update(ticket);
            _context.SaveChanges();
        }

    }
}
