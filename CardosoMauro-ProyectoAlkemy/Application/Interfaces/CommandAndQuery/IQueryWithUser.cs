using Application.Models.Response;
using Domain.Entities;

namespace Application.Interfaces.CommandAndQuery
{
    public interface IQueryWithUser<T> : IQuery<User>
    {
        Task<T> GetByEmail(string userEmail);

        Task<T> GetUserAuth(string email, string password);
    }
}
