using Newtonsoft.Json;

namespace Kinoheld.Api.Client.Model
{
    public class Url
    {
        [JsonProperty("url")]
        public string AbsoluteUrl { get; set; }
    }
}