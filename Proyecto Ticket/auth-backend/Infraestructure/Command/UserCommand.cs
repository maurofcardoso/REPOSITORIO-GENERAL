using Aplication.Interfaces;
using Domain.Entities;
using Infraestructure.Persistence;

namespace Infraestructure.Command
{
    public class UserCommand:IUserCommand
    {
        private readonly AuthDBContext _context;
        private readonly IUserQuery _userQuery;


        public UserCommand(AuthDBContext context, IUserQuery userQuery)
        {
            _context = context;
            _userQuery = userQuery;
        }

        public async Task Add(User user)
        {
            _context.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            User user = _userQuery.Get(id);
            _context.User.Remove(user);
             await _context.SaveChangesAsync();
        }

        public Task Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
