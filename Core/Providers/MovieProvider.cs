using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Core.Configuration;
using Core.Interfaces;
using Data.Models;

namespace Core.Providers
{
    public class MovieProvider : IMovieProvider
    {
        private readonly Settings _settings;
        private readonly HttpClient _httpClient;

        public MovieProvider()
        {
            _settings = new Settings();
            _httpClient = new HttpClient();
        }

        public Task<IEnumerable<Movie>> GetMovies()
        {
            throw new System.NotImplementedException();
        }
    }
}