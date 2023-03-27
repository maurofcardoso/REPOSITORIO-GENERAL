using Domain.Entities;

namespace Application.Interfaces.CommandAndQuery
{
    public interface IQueryWithMovieOrSerie <T> : IQuery<MovieOrSerie>
    {
        Task<T> GetByName(string characterName);
    }
}
