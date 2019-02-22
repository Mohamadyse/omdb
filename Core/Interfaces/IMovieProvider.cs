using Data.Models;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IMovieProvider
    {
        Task<IEnumerable<Movie>> GetMovies();
    }
}