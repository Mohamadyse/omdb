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
        private readonly ILogger<IMovieRepository> _logger;
        private const string ApiKey = "f8940a38";
        private const string BaseUrl = "http://www.omdbapi.com/";

        public MovieRepository(ILogger<IMovieRepository> logger)
        {
            _logger = logger;

        }

        public async Task<Movie> GetMovie(string queryParameters)
        {
            var url = $"{BaseUrl}?apikey={ApiKey}&{queryParameters}";
            var movie = new Movie(); // Behövs ej

            // för att HttpCient är disposal är det bättre att använda using istället
            // I Startup.cs har vi lagt in det här repot med AddScoped<>.
            // Det betyder att instansen av den här klassen kommer att disposas efter varje anrop (scope).
            // Därför behöver man inte använda using i det här fallet, man annars är det bra, ja
            using (HttpClient _httpClient = new HttpClient())
            {
                try
                {
                    // Behöver ej använda using här
                    // var responseMessage = await _httpClient.GetAsync(url);
                    using (var responseMessage = await _httpClient.GetAsync(url))
                    {

                        // Lägg till felhantering
                        // responseMessage.EnsureSuccessStatusCode();

                        var content = await responseMessage.Content.ReadAsStringAsync();

                        // Använd följande för att deserialisera från Json
                        // var result = JsonConvert.DeserializeObject<Movie>(content);
                        // return result;

                        JObject json = JObject.Parse(content);

                        movie = json.ToObject<Movie>();
                    }
                }
                catch (Exception ex)
                {
                    // Log and handle the exception
                    _logger.LogDebug(ex.Message);
                    Console.WriteLine(ex.GetType().ToString(), ex.Message); // Undvik att logga med Console.Writeline, använda bara logger
                }
            }

            return movie;
        }
    }
}