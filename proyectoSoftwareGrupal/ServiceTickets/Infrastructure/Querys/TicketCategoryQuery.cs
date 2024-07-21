using Aplication.Interfaces.ITicketCategory;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Querys
{
    public class TicketCategoryQuery : ITicketCategoryQuery
    {
        private readonly AppDbContext _context;

        public TicketCategoryQuery(AppDbContext context)
        {
            _context = context;
        }

        public TicketCategory GetTicketCategoryById(int id)
        {
            var ticketCategory = _context.TicketCategory.FirstOrDefault(a => a.idTicketCategory == id);
            return ticketCategory;
        }

        public List<TicketCategory> GetListTicketCategory()
        {
            var ticketCategory = _context.TicketCategory.ToList();
            return ticketCategory;
        }
    }
}
