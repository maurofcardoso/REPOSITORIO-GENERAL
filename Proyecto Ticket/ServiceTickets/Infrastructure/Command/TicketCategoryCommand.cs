using Aplication.Interfaces.ITicketCategory;
using Domain.Entities;
using Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Command
{
    public class TicketCategoryCommand : ITicketCategoryCommand
    {
        private readonly AppDbContext _context;

        public TicketCategoryCommand(AppDbContext context)
        {
            _context = context;
        }

        public void CreateTicketCategory(TicketCategory ticketCategory)
        {
            _context.Add(ticketCategory);
            _context.SaveChanges();
        }

        public void UpdateTicketCategory(TicketCategory ticketCategory)
        {
            _context.Update(ticketCategory);
            _context.SaveChanges();
        }
    }
}
