using Application.Interfaces.CommandAndQuery;
using Domain.Entities;
using Infraestructure.Persistence;

namespace Infraestructure.Command
{
    public class CommandGender : ICommand<Gender>
    {
        private readonly ProyectoAlkemyContext _context;

        public CommandGender(ProyectoAlkemyContext context)
        {
            _context = context;
        }

        public async Task Insert(Gender element)
        {
            _context.Add(element);
            await _context.SaveChangesAsync();
        }

        public async Task Remove(Gender element)
        {
            _context.Remove(element);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Gender element)
        {
            _context.Update(element);
            await _context.SaveChangesAsync();
        }
    }
}
