using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Interfaces;
using Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace Rest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {

        private readonly IMovieRepository _movieRepository;

        public MoviesController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        // GET
        // http://localhost:21321/api/movies/getMovies
        /// <summary>
        /// TODO: Use the provided movieRepository to get a specific movie from OMDB.
        /// TODO: Add query parameters to the GET method, and pass them to the movie repository
        /// TODO: Check the example.json file for the movie format
        /// </summary>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}