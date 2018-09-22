using System.Collections.Generic;
using Newtonsoft.Json;

namespace Kinoheld.Api.Client.Model
{
    public class MovieInfo
    {
        [JsonProperty("genres")]
        public List<Genre> Genres { get; set; }
    }
}