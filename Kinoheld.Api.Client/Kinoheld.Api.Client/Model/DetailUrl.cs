using Newtonsoft.Json;

namespace Kinoheld.Api.Client.Model
{
    public class DetailUrl
    {
        [JsonProperty("absoluteUrl")]
        public string AbsoluteUrl { get; set; }
    }
}