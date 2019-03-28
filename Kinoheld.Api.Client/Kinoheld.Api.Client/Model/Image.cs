using Newtonsoft.Json;

namespace Kinoheld.Api.Client.Model
{
    public class Image
    {
        [JsonProperty("height")]
        public int Height { get; set; }

        [JsonProperty("width")]
        public int Width { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}