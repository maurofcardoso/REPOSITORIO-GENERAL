using Aplication.Interfaces.IArea;
using Domain.Entities;
using Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Command
{
    public class AreaCommand : IAreaCommand
    {
        private readonly AppDbContext _context;

        public AreaCommand(AppDbContext context)
        {
            _context = context;
        }

        public void CreateArea(Area area)
        {
            _context.Add(area);
            _context.SaveChanges();
        }

        public void UpdateArea(Area area)
        {
            _context.Update(area);
            _context.SaveChanges();
        }
    }
}
