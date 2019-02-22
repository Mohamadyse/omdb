using Microsoft.AspNetCore.Mvc;

namespace Rest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        // GET
        // http://localhost:21321/api/movies/getMovies
        [HttpGet]
        public IActionResult GetMovies()
        {
            return Ok();
        }
    }
}