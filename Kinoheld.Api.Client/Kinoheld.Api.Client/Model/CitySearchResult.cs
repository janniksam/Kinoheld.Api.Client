using System.Collections.Generic;
using Newtonsoft.Json;

namespace Kinoheld.Api.Client.Model
{
    public class CitySearchResult
    {
        public CitySearchResult()
        {
            Cities = new List<City>();
        }

        [JsonProperty("cities")]
        public List<City> Cities { get; set; }
    }
}