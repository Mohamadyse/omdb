using System.Collections.Generic;

namespace Data.Models
{
    public class SearchResult
    {
            public IEnumerable<Movie> Movies { get; set; }
            public string TotalResults { get; set; }
            public bool Response { get; set; }
    }
}