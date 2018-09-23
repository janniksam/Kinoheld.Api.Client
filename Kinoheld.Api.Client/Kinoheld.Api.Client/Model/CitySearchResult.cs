using System.Collections.Generic;
using Newtonsoft.Json;

namespace Kinoheld.Api.Client.Model
{
    public class CitySearchResult
    {
        public CitySearchResult()
        {
            Cities = new List<City>();
            PostalCodes = new List<PostalCode>();
        }

        [JsonProperty("cities")]
        public List<City> Cities { get; set; }

        [JsonProperty("postcodes")]
        public List<PostalCode> PostalCodes { get; set; }
    }
}