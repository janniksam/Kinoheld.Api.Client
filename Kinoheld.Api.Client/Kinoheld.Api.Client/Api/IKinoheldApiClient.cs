using System;
using System.Threading.Tasks;
using Kinoheld.Api.Client.Requests;
using Newtonsoft.Json.Linq;

namespace Kinoheld.Api.Client.Api
{
    public interface IKinoheldApiClient
    {
        Task<JObject> GetCinemas(string city, string searchTerm, int distance, GetCinemasDynamicQuery dynamicQuery);

        Task<JObject> GetShows(int cinemaId, DateTime? date, GetShowsDynamicQuery dynamicQuery);

        Task<JObject> GetCities(string searchTerm, int limit);
    }
}