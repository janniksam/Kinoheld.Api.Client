using Newtonsoft.Json;

namespace Kinoheld.Api.Client.Model
{
    public class Url
    {
        [JsonProperty("absoluteUrl")]
        public string AbsoluteUrl { get; set; }
    }
}