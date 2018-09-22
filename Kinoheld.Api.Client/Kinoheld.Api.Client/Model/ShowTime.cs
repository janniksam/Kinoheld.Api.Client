using Newtonsoft.Json;

namespace Kinoheld.Api.Client.Model
{
    public class ShowTime
    {
        [JsonProperty("formatted")]
        public string Formatted { get; set; }
    }
}