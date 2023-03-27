using Application.Interfaces.CommandAndQuery;
using Application.Models.Request;
using Domain.Entities;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Query
{
    public class QueryCharacter : IQueryWithCharacter<CharacterRequest, Character>
    {
        private readonly ProyectoAlkemyContext _context;

        public QueryCharacter(ProyectoAlkemyContext context)
        {
            _context = context;
        }

        public async Task<Character> GetById(int elementId)
        {
            if (elementId < 1)
            {
                return null;
            }
            var character = await _context.Characters.Where(g => g.CharacterId == elementId).Include(p => p.MoviesOrSeriesAssociated).FirstOrDefaultAsync();
            if (character == null)
            {
                return null;
            }
            return character;
        }

        public async Task<Character> GetByRequest(CharacterRequest characterRequest)
        {
            if (characterRequest == null)
            {
                return null;
            }
            var character = await _context.Characters.Where(p => p.Name == characterRequest.Name && p.Age == characterRequest.Age).Include(p => p.MoviesOrSeriesAssociated).FirstOrDefaultAsync();
            if (character == null)
            {
                return null;
            }
            return character;
        }

        public async Task<IEnumerable<Character>> GetList()
        {
            var character = await _context.Characters.Include(p => p.MoviesOrSeriesAssociated).ToListAsync();
            return character;
        }

        public async Task<Character> GetByName(string characterName)
        {
            if (characterName == null)
            {
                return null;
            }
            var character = await _context.Characters.Where(p => p.Name == characterName).Include(p => p.MoviesOrSeriesAssociated).FirstOrDefaultAsync();
            if (character == null)
            {
                return null;
            }
            return character;
        }

        public async Task<Character> GetByAge(int characterAge)
        {
            if (characterAge < 0)
            {
                return null;
            }
            var character = await _context.Characters.Where(p => p.Age == characterAge).Include(p => p.MoviesOrSeriesAssociated).FirstOrDefaultAsync();
            if (character == null)
            {
                return null;
            }
            return character;
        }
    }
}
