using Application.Models.Request;
using Domain.Entities;

namespace Application.Interfaces.ServiceCommandAndQuery
{
    public interface IServiceQueryWithMovieOrSerie <T> : IServiceCommand<MovieOrSerieRequest, MovieOrSerie>, IServiceQuery<MovieOrSerie>
    {
        Task<T> GetByName(string characcterName);

        Task<IEnumerable<T>> GetByGenderId(int genderId);
    }
}
