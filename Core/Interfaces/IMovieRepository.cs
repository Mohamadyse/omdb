using System.Collections.Generic;
using Data.Models;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IMovieRepository
    {
        Task<Movie> GetMovie(string queryParameters);
        Task<SearchResult> SearchMovie(string queryParameters);

    }
}