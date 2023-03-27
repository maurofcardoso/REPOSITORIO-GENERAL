using Application.Interfaces.CommandAndQuery;
using Domain.Entities;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Query
{
    public class QueryCharacterMovieOrSerie : IQuery<CharacterMovieOrSerie>
    {
        private readonly ProyectoAlkemyContext _context;

        public QueryCharacterMovieOrSerie(ProyectoAlkemyContext context)
        {
            _context = context;
        }

        public async Task<CharacterMovieOrSerie> GetById(int elementId)
        {
            if (elementId < 1)
            {
                return null;
            }
            var characterMovieOSerie = await _context.CharactersMoviesOrSeries.Where(g => g.CharacterId == elementId).Include(p => p.MovieOrSerie).FirstOrDefaultAsync();
            if (characterMovieOSerie == null)
            {
                return null;
            }
            return characterMovieOSerie;
        }

        public async Task<IEnumerable<CharacterMovieOrSerie>> GetList()
        {
            var characterMovieOrSerie = await _context.CharactersMoviesOrSeries.Include(p => p.MovieOrSerie).Include(p => p.Character).ToListAsync();
            return characterMovieOrSerie;
        }
    }
}
