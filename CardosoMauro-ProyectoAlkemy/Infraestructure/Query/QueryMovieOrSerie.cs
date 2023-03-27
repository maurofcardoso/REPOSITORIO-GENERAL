using Application.Interfaces.CommandAndQuery;
using Domain.Entities;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Query
{
    public class QueryMovieOrSerie : IQueryWithMovieOrSerie<MovieOrSerie>
    {
        private readonly ProyectoAlkemyContext _context;

        public QueryMovieOrSerie(ProyectoAlkemyContext context)
        {
            _context = context;
        }

        public async Task<MovieOrSerie> GetById(int elementId)
        {
            if (elementId < 1)
            {
                return null;
            }
            var movieOrSerie = await _context.MoviesOrSeries.Where(g => g.MovieOrSerieId == elementId).Include(p => p.CharacterAssociated).Include(g => g.Gender).FirstOrDefaultAsync();
            if (movieOrSerie == null)
            {
                return null;
            }
            return movieOrSerie;
        }

        public async Task<IEnumerable<MovieOrSerie>> GetList()
        {
            var movieOrSerie = await _context.MoviesOrSeries.Include(p => p.CharacterAssociated).Include(g => g.Gender).ToListAsync();
            return movieOrSerie;
        }

        public async Task<MovieOrSerie> GetByName(string movieOrSerieName)
        {
            if (movieOrSerieName == null)
            {
                return null;
            }
            var movieOrSerie = await _context.MoviesOrSeries.Where(p => p.Title == movieOrSerieName).Include(p => p.CharacterAssociated).FirstOrDefaultAsync();
            if (movieOrSerie == null)
            {
                return null;
            }
            return movieOrSerie;
        }
    }
}
