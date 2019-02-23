using System;
using Data.Models;
using Newtonsoft.Json.Linq;

namespace Core.mappers
{
    public class JsonToMovie
    {
        private readonly JObject _json;

        public JsonToMovie  (JObject json)
        {
            _json = json;
        }

        public static Movie Convert(JObject json)
        {
           

            return  new Movie();
            
        }
     }
}