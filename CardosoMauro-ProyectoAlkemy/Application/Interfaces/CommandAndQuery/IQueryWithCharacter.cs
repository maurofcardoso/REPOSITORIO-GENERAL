using Application.Models.Request;
using Domain.Entities;

namespace Application.Interfaces.CommandAndQuery
{
    public interface IQueryWithCharacter<TR, T> : IQuery<Character>
    {
        Task<T> GetByRequest (TR characterRequest);

        Task<T> GetByName(string characterName);

        Task<T> GetByAge(int characterAge);
    }
}
