using Application.Interfaces.CommandAndQuery;
using Domain.Entities;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Query
{
    public class QueryGender :IQuery<Gender>
    {
        private readonly ProyectoAlkemyContext _context;

        public QueryGender(ProyectoAlkemyContext context)
        {
            _context = context;
        }

        public async Task<Gender> GetById(int elementId)
        {
            if (elementId < 1)
            {
                return null;
            }
            var gender = await _context.Genders.Where(g => g.GenderId == elementId).Include(p => p.MoviesOrSeriesAssociated).FirstOrDefaultAsync();
            if (gender == null)
            {
                return null;
            }
            return gender;
        }

        public async Task<IEnumerable<Gender>> GetList()
        {
            var genero = await _context.Genders.Include(p => p.MoviesOrSeriesAssociated).ToListAsync();
            return genero;
        }
    }
}
