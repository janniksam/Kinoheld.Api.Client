using Newtonsoft.Json;

namespace Kinoheld.Api.Client.Model
{
    public class Genre
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}