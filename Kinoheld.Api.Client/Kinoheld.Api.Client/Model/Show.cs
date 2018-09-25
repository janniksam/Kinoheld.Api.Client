using System.Collections.Generic;
using Newtonsoft.Json;

namespace Kinoheld.Api.Client.Model
{
    public class Show
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("beginning")]
        public ShowTime Beginning { get; set; }

        [JsonProperty("detailUrl")]
        public DetailUrl DetailUrl { get; set; }

        [JsonProperty("movie")]
        public MovieInfo MovieInfo { get; set; }

        [JsonProperty("flags")]
        public List<Flag> Flags { get; set; }

        public override string ToString()
        {
            return $"{Name} ({Beginning?.Formatted})";
        }
    }
}