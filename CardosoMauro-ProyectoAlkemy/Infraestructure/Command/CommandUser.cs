using Application.Interfaces.CommandAndQuery;
using Domain.Entities;
using Infraestructure.Persistence;

namespace Infraestructure.Command
{
    public class CommandUser :ICommand<User>
    {
        private readonly ProyectoAlkemyContext _context;

        public CommandUser(ProyectoAlkemyContext context)
        {
            _context = context;
        }

        public async Task Insert(User element)
        {
            _context.Add(element);
            await _context.SaveChangesAsync();
        }

        public async Task Remove(User element)
        {
            _context.Remove(element);
            await _context.SaveChangesAsync();
        }

        public async Task Update(User element)
        {
            _context.Update(element);
            await _context.SaveChangesAsync();
        }
    }
}
