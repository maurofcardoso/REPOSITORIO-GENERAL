using Application.Interfaces.CommandAndQuery;
using Domain.Entities;
using Infraestructure.Persistence;

namespace Infraestructure.Command
{
    public class CommandCharacterMovieOrSerie : ICommand<CharacterMovieOrSerie>
    {
        private readonly ProyectoAlkemyContext _context;

        public CommandCharacterMovieOrSerie(ProyectoAlkemyContext context)
        {
            _context = context;
        }

        public async Task Insert(CharacterMovieOrSerie element)
        {
            _context.Add(element);
            await _context.SaveChangesAsync();
        }

        public async Task Remove(CharacterMovieOrSerie element)
        {
            _context.Remove(element);
            await _context.SaveChangesAsync();
        }

        public async Task Update(CharacterMovieOrSerie element)
        {
            _context.Update(element);
            await _context.SaveChangesAsync();
        }
    }
}
