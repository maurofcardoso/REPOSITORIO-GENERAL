using Application.Models.Request;
using Application.Models.Response;
using Domain.Entities;

namespace Application.Interfaces.ServiceCommandAndQuery
{
    public interface IServiceQueryWithUser<T> : IServiceCommand<UserRequest, User>, IServiceQuery<User>
    {
        Task<T> GetUser(string usuarioEmail);

        Task<PayloadUserResponse> GetUserAuth(string email, string password);

        string GetToken(User userAuth);

        Task<T> exists(string email);
    }
}
