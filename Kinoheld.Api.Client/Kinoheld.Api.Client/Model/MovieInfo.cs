using System.Collections.Generic;
using Newtonsoft.Json;

namespace Kinoheld.Api.Client.Model
{
    public class MovieInfo
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("thumb")]
        public Image[] ThumbnailImage { get; set; }

        [JsonProperty("genres")]
        public List<Genre> Genres { get; set; }
    }
}