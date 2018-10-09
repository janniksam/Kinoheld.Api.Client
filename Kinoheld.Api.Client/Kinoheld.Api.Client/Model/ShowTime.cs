using System;
using Kinoheld.Api.Client.Helper;
using Newtonsoft.Json;

namespace Kinoheld.Api.Client.Model
{
    public class ShowTime
    {
        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }

        public DateTime GetDateTime()
        {
            return Timestamp.ToGermanDateTime();
        }
    }
}