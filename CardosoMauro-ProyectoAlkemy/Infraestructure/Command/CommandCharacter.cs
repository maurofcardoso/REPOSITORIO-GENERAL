using Application.Interfaces.CommandAndQuery;
using Domain.Entities;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Command
{
    public class CommandCharacter : ICommand<Character>
    {
        private readonly ProyectoAlkemyContext _context;

        public CommandCharacter(ProyectoAlkemyContext context)
        {
            this._context = context;
        }

        public async Task Insert(Character element)
        {
            _context.Add(element);
            await _context.SaveChangesAsync();
        }

        public async Task Remove(Character element)
        {
            _context.Remove(element);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Character element)
        {
            _context.Update(element);
            await _context.SaveChangesAsync();
        }
    }
}
