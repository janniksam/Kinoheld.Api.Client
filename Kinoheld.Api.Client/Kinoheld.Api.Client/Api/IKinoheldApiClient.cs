using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Kinoheld.Api.Client.Api
{
    public interface IKinoheldApiClient
    {
        Task<JObject> GetCinemas(string city, string searchTerm, int distance);

        Task<JObject> GetShows(int cinemaId, DateTime? date);
    }
}