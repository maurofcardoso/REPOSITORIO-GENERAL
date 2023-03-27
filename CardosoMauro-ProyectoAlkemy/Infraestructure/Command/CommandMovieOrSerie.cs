using Application.Interfaces.CommandAndQuery;
using Domain.Entities;
using Infraestructure.Persistence;

namespace Infraestructure.Command
{
    public class CommandMovieOrSerie : ICommand<MovieOrSerie>
    {
        private readonly ProyectoAlkemyContext _context;

        public CommandMovieOrSerie(ProyectoAlkemyContext context)
        {
            _context = context;
        }

        public async Task Insert(MovieOrSerie element)
        {
            _context.Add(element);
            await _context.SaveChangesAsync();
        }

        public async Task Remove(MovieOrSerie element)
        {
            _context.Remove(element);
            await _context.SaveChangesAsync();
        }

        public async Task Update(MovieOrSerie element)
        {
            _context.Update(element);
            await _context.SaveChangesAsync();
        }
    }
}
