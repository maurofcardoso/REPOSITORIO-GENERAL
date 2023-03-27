using Application.Exceptions;
using Application.Interfaces.Mappers;
using Application.Interfaces.ServiceCommandAndQuery;
using Application.Models.Request;
using Application.Models.Response;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Web;

namespace ProyectoAlkemy.Controllers
{
    [Route("movies")]
    [ApiController]
    public class moviesController : ControllerBase
    {
        private readonly IServiceQueryWithMovieOrSerie<MovieOrSerie> _queryMovieOrSerie;
        private readonly IMapperDisney _mapper;

        public moviesController(IServiceQueryWithMovieOrSerie<MovieOrSerie> queryMovieOrSerie, IMapperDisney mapper)
        {
            _queryMovieOrSerie = queryMovieOrSerie;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetMoviesOrSeries (string? name, int? gender, string? order)
        {
            try
            {
                if (Request.QueryString.Value == "")
                {
                    IEnumerable<MovieOrSerie> movieOrSeries = await _queryMovieOrSerie.GetListElement();
                    if (movieOrSeries == null)
                    {
                        return new JsonResult(movieOrSeries) { StatusCode = 404 };
                    }
                    if (movieOrSeries.Count() < 1)
                    {
                        return new JsonResult("La lista esta vacia") { StatusCode = 200 };
                    }
                    List<MovieOrSerieResponseMin> moviesOrSeriesResponse = new List<MovieOrSerieResponseMin>();
                    foreach (MovieOrSerie movieOrSerie in movieOrSeries)
                    {
                        moviesOrSeriesResponse.Add(_mapper.MovieOrSerieAtMovieOrSerieResponseMin(movieOrSerie));
                    }
                    return new JsonResult(moviesOrSeriesResponse) { StatusCode = 200 };
                }
                var option = Request.Query.FirstOrDefault().Key.ToString();
                var value = Request.Query.FirstOrDefault().Value.ToString();
                if (option == "name" && value != null)
                {
                    MovieOrSerie movieOrSerie = await _queryMovieOrSerie.GetByName(value);
                    if (movieOrSerie == null)
                    {
                        return new JsonResult(movieOrSerie) { StatusCode = 404 };
                    }
                    return new JsonResult(await _mapper.MovieOrSerieAtMovieOrSerieResponse(movieOrSerie)) { StatusCode = 200 };
                }
                if (option == "gender" && value != null)
                {
                    IEnumerable<MovieOrSerie> movieOrSeries = await _queryMovieOrSerie.GetByGenderId(int.Parse(value));
                    if (movieOrSeries == null || movieOrSeries.Count() < 1)
                    {
                        return new JsonResult(movieOrSeries) { StatusCode = 404 };
                    }
                    List<MovieOrSerieResponse> movieOrSerieList = new List<MovieOrSerieResponse>();
                    foreach (MovieOrSerie x in movieOrSeries)
                    {
                        movieOrSerieList.Add(await _mapper.MovieOrSerieAtMovieOrSerieResponse(x));
                    }
                    return new JsonResult(movieOrSerieList) { StatusCode = 200 };
                }
                if (option == "order" && value != null)
                {
                    IEnumerable<MovieOrSerie> movieOrSeries = await _queryMovieOrSerie.GetListElement();
                    if (movieOrSeries == null || movieOrSeries.Count() < 1)
                    {
                        return new JsonResult(movieOrSeries) { StatusCode = 404 };
                    }
                    List<MovieOrSerieResponse> movieOrSerieList = new List<MovieOrSerieResponse>();
                    foreach (MovieOrSerie x in movieOrSeries)
                    {
                        movieOrSerieList.Add(await _mapper.MovieOrSerieAtMovieOrSerieResponse(x));
                    }
                    if (value.ToUpper() == "DESC")
                    {
                        return new JsonResult(movieOrSerieList.OrderByDescending(p => p.CreationDate)) { StatusCode = 200 };
                    }
                    return new JsonResult(movieOrSerieList) { StatusCode = 200 };
                }
                return new JsonResult("Error al ingresar datos.");
            }
            catch (ItemDuplicate e)
            {
                return BadRequest(e.message);
            }
            catch (ItemNotFound e)
            {
                return NotFound(e.message);
            }
            catch (ItemError e)
            {
                return BadRequest(e.message);
            }
            catch (Exception)
            {
                return BadRequest("Hubo un error.");
            }
        }

        [HttpGet ("detail")]
        public async Task<IActionResult> GetMovieOrSerieDetail()
        {
            try
            {
                IEnumerable<MovieOrSerie> movieOrSeries = await _queryMovieOrSerie.GetListElement();
                if (movieOrSeries == null)
                {
                    return new JsonResult(movieOrSeries) { StatusCode = 404 };
                }
                if (movieOrSeries.Count() < 1)
                {
                    return new JsonResult("La lista esta vacia") { StatusCode = 200 };
                }
                List<MovieOrSerieResponse> moviesOrSeriesResponse = new List<MovieOrSerieResponse>();
                foreach (MovieOrSerie movieOrSerie in movieOrSeries)
                {
                    moviesOrSeriesResponse.Add(await _mapper.MovieOrSerieAtMovieOrSerieResponse(movieOrSerie));
                }
                return new JsonResult(moviesOrSeriesResponse) { StatusCode = 200 };

            }
            catch (ItemDuplicate e)
            {
                return BadRequest(e.message);
            }
            catch (ItemNotFound e)
            {
                return NotFound(e.message);
            }
            catch (ItemError e)
            {
                return BadRequest(e.message);
            }
            catch (Exception)
            {
                return BadRequest("Hubo un error.");
            }
        }

        [HttpPost("addMovieOrSerie")]
        public async Task<IActionResult> CreateMovieOrSerie ([FromBody]MovieOrSerieRequest movieOrSerieRequest)
        {
            if (movieOrSerieRequest == null)
            {
                return new JsonResult(movieOrSerieRequest) { StatusCode = 404 };
            }
            try
            {
                MovieOrSerie movieOrSerie = await _queryMovieOrSerie.CreateElement(movieOrSerieRequest);
                if (movieOrSerie == null)
                {
                    return new JsonResult(movieOrSerie) { StatusCode = 404 };
                }
                return new JsonResult(_mapper.MovieOrSerieAtMovieOrSerieResponse(movieOrSerie)) { StatusCode = 200 };
            }
            catch (ItemDuplicate e)
            {
                return BadRequest(e.message);
            }
            catch (ItemNotFound e)
            {
                return NotFound(e.message);
            }
            catch (ItemError e)
            {
                return BadRequest(e.message);
            }
            catch (Exception)
            {
                return BadRequest("Hubo un error.");
            }
        }

        [HttpPut("updateMovieOrSerie/{movieOrSerieId:int}")]
        public async Task<IActionResult> UpdateMovieOrSerie ([FromBody]MovieOrSerieRequest movieOrSerieRequest, int movieOrSerieId)
        {
            if (movieOrSerieRequest == null)
            {
                return new JsonResult(movieOrSerieRequest) { StatusCode = 404 };
            }
            try
            {
                MovieOrSerie movieOrSerie = await _queryMovieOrSerie.UpdateElement(movieOrSerieRequest, movieOrSerieId);
                if (movieOrSerie == null)
                {
                    return new JsonResult(movieOrSerie) { StatusCode = 404 };
                }
                return new JsonResult(_mapper.MovieOrSerieAtMovieOrSerieResponse(movieOrSerie)) { StatusCode = 200 };
            }
            catch (ItemDuplicate e)
            {
                return BadRequest(e.message);
            }
            catch (ItemNotFound e)
            {
                return NotFound(e.message);
            }
            catch (ItemError e)
            {
                return BadRequest(e.message);
            }
            catch (Exception)
            {
                return BadRequest("Hubo un error.");
            }
        }

        [HttpDelete("removeMovieOrSerie/{movieOrSerieId:int}")]
        public async Task<IActionResult> RemoveMovieOrSerie (int movieOrSerieId)
        {
            if (movieOrSerieId < 1)
            {
                return new JsonResult(movieOrSerieId) { StatusCode = 404 };
            }
            try
            {
                MovieOrSerie movieOrSerie = await _queryMovieOrSerie.DeleteElement(movieOrSerieId);
                if (movieOrSerie == null)
                {
                    return new JsonResult(movieOrSerie) { StatusCode = 404 };
                }
                return new JsonResult(_mapper.MovieOrSerieAtMovieOrSerieResponse(movieOrSerie)) { StatusCode = 200 };
            }
            catch (ItemDuplicate e)
            {
                return BadRequest(e.message);
            }
            catch (ItemNotFound e)
            {
                return NotFound(e.message);
            }
            catch (ItemError e)
            {
                return BadRequest(e.message);
            }
            catch (Exception)
            {
                return BadRequest("Hubo un error.");
            }
        }
    }
}
