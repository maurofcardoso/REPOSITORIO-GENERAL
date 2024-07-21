using Aplication.Interfaces.ITicketComment;
using Domain.Entities;
using Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Command
{
    public class TicketCommentCommand : ITicketCommentCommand
    {
        private readonly AppDbContext _context;

        public TicketCommentCommand(AppDbContext context)
        {
            _context = context;
        }

        public void CreateTicketComment(TicketComment ticketComment)
        {
            _context.Add(ticketComment);
            _context.SaveChanges();
        }
        public void RemoveTicketComment(TicketComment ticketComment)
        {
            _context.Remove(ticketComment);
            _context.SaveChanges();
        }

        public async Task UpdateTicketComment(TicketComment ticketComment)
        {
            _context.Update(ticketComment);
            await _context.SaveChangesAsync();
        }
    }
}
