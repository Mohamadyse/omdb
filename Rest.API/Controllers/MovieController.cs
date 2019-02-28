using System;
using Core.Interfaces;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Rest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieRepository _movieRepository;
        private readonly ILogger<MoviesController> _logger;

        public MoviesController(IMovieRepository movieRepository, ILogger<MoviesController> logger)
        {
            _movieRepository = movieRepository;
            _logger = logger;
        }
        // GET
        // http://localhost:21321/api/movies/getMovies
        /// <summary>
        /// TODO: Use the provided movieRepository to get a specific movie from OMDB.
        /// TODO: Add query parameters to the GET method, and pass them to the movie repository
        /// TODO: Check the example.json file for the movie format
        /// </summary>
        [HttpGet("get/{queryString}")]
        public async Task<IActionResult> Get(string queryString)
        {
            try
            {
                var movie = await _movieRepository.GetMovie(queryString);
                if (movie == null)
                {
                    return NotFound();
                }
                return new JsonResult(movie);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new JsonResult(Response) { StatusCode = 500 };
            }
        }

        [HttpGet("search/{queryString}")]
        public async Task<IActionResult> Search(string queryString)
        {
            try
            {
                var searchElement = await _movieRepository.SearchMovie(queryString);
                if (searchElement == null)
                {
                    return NotFound();
                }
                return new JsonResult(searchElement);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return new JsonResult(Response){StatusCode=500};
            }
        }
    }
}