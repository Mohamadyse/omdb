using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Core.Interfaces;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Core.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly ILogger<IMovieRepository> _logger;
        private const string ApiKey = "f8940a38";
        private const string BaseUrl = "http://www.omdbapi.com/?apikey=";
        private readonly string ApiRequest = $"http://www.omdbapi.com/?apikey={ApiKey}&";
        private readonly HttpClient _httpClient;

        public MovieRepository(ILogger<IMovieRepository> logger,  HttpClient httpClient)
        {
            _httpClient = httpClient;
            _logger = logger;
        }
        public async Task<Movie> GetMovie(string queryParameters)
        {
            var url = $"{ApiRequest}{queryParameters}";
            try
            {

                var responseMessage = await _httpClient.GetAsync(url);
                responseMessage.EnsureSuccessStatusCode();
                var content = await responseMessage.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Movie>(content);
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex.Message, "failed to request the movie");
                throw;
            }

        }

        public async Task<SearchResult> SearchMovie(string queryParameters)
        {
            var url = $"{ApiRequest}{queryParameters}";
            var responseMessage = await _httpClient.GetAsync(url);
            var content = await responseMessage.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<SearchResult>(content);
        }
    }
}