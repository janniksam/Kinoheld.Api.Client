using Newtonsoft.Json;

namespace Kinoheld.Api.Client.Model
{
    public class PostalCode
    {
        [JsonProperty("postcode")]
        public int Code { get; set; }

        [JsonProperty("city")]
        public City City { get; set; }

    }
}