using System;
using System.Net.Http;
using System.Threading.Tasks;
using Core.Interfaces;
using Data.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Core.Repositories
{
    public class MovieRepository : IMovieRepository
    {
       // private readonly HttpClient _httpClient;
        private ILogger<IMovieRepository> _logger;
        private const string ApiKey = "f8940a38";
        private const string BaseUrl = "http://www.omdbapi.com/";

        public MovieRepository(ILogger<IMovieRepository> logger)
        {
            _logger = logger;
           
        }

        public async Task<Movie> GetMovie(string queryParameters)
        {
            var url = $"{BaseUrl}?apikey={ApiKey}{queryParameters}";


            // för att HttpCient är disposal ät det bättre att använda using istället
            using (HttpClient _httpClient = new HttpClient())
                try
                {
                    
                    using (var responseMessage = await _httpClient.GetAsync(url))
                    {

                        var content = await responseMessage.Content.ReadAsStringAsync();

                        JObject json = JObject.Parse(content);
                        return json.ToObject<Movie>();




                        // Remove this and instead map JSON from the response to a list of the actual model "Movie"
                        // Use JsonConvert to deserialize from Json to Movie
                      //  dynamic jsonMovie = JsonConvert.DeserializeObject(content);





                    }
                }
                catch (Exception ex)
                {
                    // Log and handle the exception
                    _logger.LogDebug(ex.Message);
                   
                }
        }
    }
}