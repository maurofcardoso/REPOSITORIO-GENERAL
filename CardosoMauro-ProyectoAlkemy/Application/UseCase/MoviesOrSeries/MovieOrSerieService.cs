using Application.Exceptions;
using Application.Interfaces.CommandAndQuery;
using Application.Interfaces.Mappers;
using Application.Interfaces.ServiceCommandAndQuery;
using Application.Models.Request;
using Domain.Entities;

namespace Application.UseCase.MoviesOrSeries
{
    public class MovieOrSerieService : IServiceQueryWithMovieOrSerie<MovieOrSerie>
    {
        private readonly ICommand<MovieOrSerie> _commandMovieOrSerie;
        private readonly IQueryWithMovieOrSerie<MovieOrSerie> _queryMovieOrSerie;
        private readonly IMapperDisney _mapperDisney;

        public MovieOrSerieService(ICommand<MovieOrSerie> commandMovieOrSerie, IQueryWithMovieOrSerie<MovieOrSerie> queryMovieOrSerie, IMapperDisney mapperDisney)
        {
            _commandMovieOrSerie = commandMovieOrSerie;
            _queryMovieOrSerie = queryMovieOrSerie;
            _mapperDisney = mapperDisney;
        }

        public async Task<MovieOrSerie> CreateElement(MovieOrSerieRequest elementRequest)
        {
            if (elementRequest == null)
            {
                throw new ItemError("Error en ingreso de datos.");
            }

            MovieOrSerie movieOrSerie = _mapperDisney.MovieOrSerieRequestAtMovieOrSerie(elementRequest);

            await _commandMovieOrSerie.Insert(movieOrSerie);

            return movieOrSerie;
        }

        public async Task<MovieOrSerie> DeleteElement(int elementId)
        {
            if (elementId < 1)
            {
                throw new ItemError("Error en ingreso de datos.");
            }

            MovieOrSerie movieOrSerie = await this.exists(elementId);
            if (movieOrSerie == null)
            {
                throw new ItemDuplicate("El personaje no existe.");
            }

            await _commandMovieOrSerie.Remove(movieOrSerie);
            return movieOrSerie;
        }

        public async Task<MovieOrSerie> exists(int elementId)
        {
            if (elementId < 1)
            {
                throw new ItemError("Error en ingreso de datos");
            }

            MovieOrSerie movieOrSerie = await _queryMovieOrSerie.GetById(elementId);
            if (movieOrSerie == null)
            {
                return null;
            }
            return movieOrSerie;
        }

        public async Task<MovieOrSerie> GetElement(int elementId)
        {
            if (elementId < 1)
            {
                throw new ItemError("El valor ingresado es incorrecto.");
            }

            MovieOrSerie movieOrSerie = await _queryMovieOrSerie.GetById(elementId);

            if (movieOrSerie == null)
            {
                throw new ItemNotFound("No hay coincidencias.");
            }

            return movieOrSerie;
        }

        public async Task<IEnumerable<MovieOrSerie>> GetListElement()
        {
            return await _queryMovieOrSerie.GetList();
        }

        public async Task<MovieOrSerie> UpdateElement(MovieOrSerieRequest elementRequest, int elementId)
        {
            if (elementId < 1 || elementRequest == null)
            {
                throw new ItemError("Error en ingreso de datos.");
            }

            MovieOrSerie movieOrSerie = await this.exists(elementId);
            if (movieOrSerie == null)
            {
                throw new ItemDuplicate("El personaje no existe.");
            }

            movieOrSerie = _mapperDisney.MovieOrSerieAtMovieOrSerieUpdate(movieOrSerie, elementRequest);
            await _commandMovieOrSerie.Update(movieOrSerie);
            return movieOrSerie;
        }

        public async Task<MovieOrSerie> GetByName(string movieOrSerieName)
        {
            if (movieOrSerieName == null)
            {
                throw new ItemError("Error en ingreso de datos.");
            }
            MovieOrSerie movieOrSerie = await _queryMovieOrSerie.GetByName(movieOrSerieName);
            if (movieOrSerie == null)
            {
                return null;
            }
            return movieOrSerie;
        }

        public async Task<IEnumerable<MovieOrSerie>> GetByGenderId(int genderId)
        {
            if (genderId < 1)
            {
                throw new ItemError("Error en ingreso de datos.");
            }

            List<MovieOrSerie> movieOrSerieList = new List<MovieOrSerie>();
            IEnumerable<MovieOrSerie> movieOrSeries = await _queryMovieOrSerie.GetList();
            if (movieOrSeries == null || movieOrSeries.Count() < 1)
            {
                throw new ItemNotFound("No hay coincidencias.");
            }
            foreach (MovieOrSerie x in movieOrSeries)
            {
                if (x.GenderId == genderId)
                {
                    movieOrSerieList.Add(x);
                }
            }
            if (movieOrSerieList == null || movieOrSerieList.Count() < 1)
            {
                throw new ItemNotFound("No hay coincidencias.");
            }
            return movieOrSerieList;
        }
    }
}
