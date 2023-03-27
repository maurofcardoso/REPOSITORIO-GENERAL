using Application.Interfaces.CommandAndQuery;
using Application.Interfaces.Mappers;
using Application.Interfaces.ServiceCommandAndQuery;
using Application.Models.Request;
using Domain.Entities;

namespace Application.UseCase.CharactersMoviesOrSeries
{
    public class CharacterMovieOrSerieService : IServiceCommand<CharacterMovieOrSerieRequest, CharacterMovieOrSerie>, IServiceQuery<CharacterMovieOrSerie>
    {
        private readonly ICommand<CharacterMovieOrSerie> _commandCharacterMovieOrSerie;
        private readonly IQuery<CharacterMovieOrSerie> _queryCharacterMovieOrSerie;
        private readonly IMapperDisney _mapperDisney;

        public CharacterMovieOrSerieService(ICommand<CharacterMovieOrSerie> commandCharacterMovieOrSerie, IQuery<CharacterMovieOrSerie> queryCharacterMovieOrSerie, IMapperDisney mapperDisney)
        {
            _commandCharacterMovieOrSerie = commandCharacterMovieOrSerie;
            _queryCharacterMovieOrSerie = queryCharacterMovieOrSerie;
            _mapperDisney = mapperDisney;
        }

        public Task<CharacterMovieOrSerie> CreateElement(CharacterMovieOrSerieRequest elementRequest)
        {
            throw new NotImplementedException();
        }

        public Task<CharacterMovieOrSerie> DeleteElement(int elementId)
        {
            throw new NotImplementedException();
        }

        public Task<CharacterMovieOrSerie> exists(int elementId)
        {
            throw new NotImplementedException();
        }

        public Task<CharacterMovieOrSerie> GetElement(int elementId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CharacterMovieOrSerie>> GetListElement()
        {
            throw new NotImplementedException();
        }

        public Task<CharacterMovieOrSerie> UpdateElement(CharacterMovieOrSerieRequest elementRequest, int elementId)
        {
            throw new NotImplementedException();
        }
    }
}
