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
    }
}