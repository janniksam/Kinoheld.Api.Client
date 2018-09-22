using Newtonsoft.Json;

namespace Kinoheld.Api.Client.Model
{
    public class City
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}