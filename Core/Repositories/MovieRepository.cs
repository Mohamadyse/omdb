using System;
using System.Net.Http;
using System.Threading.Tasks;
using Core.Interfaces;
using Data.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Core.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly HttpClient _httpClient;
        private ILogger<IMovieRepository> _logger;
        private const string ApiKey = "f8940a38";
        private const string BaseUrl = "http://www.omdbapi.com/";

        public MovieRepository(ILogger<IMovieRepository> logger)
        {
            _logger = logger;
            _httpClient = new HttpClient();
        }

        public async Task<Movie> GetMovie(string queryParameters)
        {
            try
            {
                var url = $"{BaseUrl}?apikey={ApiKey}{queryParameters}";
                var responseMessage = await _httpClient.GetAsync(url);

                var content = await responseMessage.Content.ReadAsStringAsync();

                // Remove this and instead map JSON from the response to a list of the actual model "Movie"
                // Use JsonConvert to deserialize from Json to Movie
                return new Movie();
            }
            catch (Exception ex)
            {
                // Log and handle the exception
                throw; 
            }
        }
    }
}