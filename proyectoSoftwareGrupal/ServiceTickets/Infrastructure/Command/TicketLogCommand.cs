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
    public class TicketLogCommand : ITicketLogCommand
    {
        private readonly AppDbContext _context;

        public TicketLogCommand(AppDbContext context)
        {
            _context = context;
        }

        public void CreateTicketLog(TicketLog ticketLog)
        {
            _context.Add(ticketLog);
            _context.SaveChanges();
        }
    }
}
