using System;
using System.Threading;
using System.Threading.Tasks;
using Kinoheld.Api.Client.Requests;
using Newtonsoft.Json.Linq;

namespace Kinoheld.Api.Client.Api
{
    public interface IKinoheldApiClient
    {
        Task<JObject> GetCinemas(string city, string searchTerm, int distance, GetCinemasDynamicQuery dynamicQuery, CancellationToken cancellationToken);

        Task<JObject> GetShows(long cinemaId, DateTime? date, GetShowsDynamicQuery dynamicQuery, CancellationToken cancellationToken);

        Task<JObject> GetCities(string searchTerm, int limit, CancellationToken cancellationToken);
    }
}