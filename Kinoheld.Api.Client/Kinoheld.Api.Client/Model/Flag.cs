using Newtonsoft.Json;

namespace Kinoheld.Api.Client.Model
{
    public class Flag
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}