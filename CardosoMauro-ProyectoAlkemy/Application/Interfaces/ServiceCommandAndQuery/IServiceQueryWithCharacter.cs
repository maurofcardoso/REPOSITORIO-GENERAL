using Application.Models.Request;
using Domain.Entities;

namespace Application.Interfaces.ServiceCommandAndQuery
{
    public interface IServiceQueryWithCharacter<TR, T> : IServiceCommand<CharacterRequest, Character>, IServiceQuery<Character>
    {
        Task<T> GetByRequest(TR characterRequest);

        Task<T> GetByName(string characcterName);

        Task<T> GetByAge(int characterAge);

        Task<IEnumerable<T>> GetByMoviOrSerieId (int moviOrSerieId);
    }
}
