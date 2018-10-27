using System;
using Newtonsoft.Json;

namespace Kinoheld.Api.Client.Model
{
    public class Cinema
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("street")]
        public string Street { get; set; }

        [JsonProperty("city")]
        public City City { get; set; }

        [JsonProperty("distance")]
        public double? Distance { get; set; }

        [JsonProperty("detailUrl")]
        public Url DetailUrl { get; set; }
    }
}