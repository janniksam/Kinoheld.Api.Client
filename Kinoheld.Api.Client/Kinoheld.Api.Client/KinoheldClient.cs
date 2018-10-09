using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kinoheld.Api.Client.Api;
using Kinoheld.Api.Client.Model;
using Kinoheld.Api.Client.Json;
using Kinoheld.Api.Client.Requests;
using System.Threading;

namespace Kinoheld.Api.Client
{
    public class KinoheldClient : IKinoheldClient
    {
        private readonly IKinoheldApiClient m_client;
        private readonly IKinoheldJsonWorker m_jsonWorker;

        public KinoheldClient()
        {
            m_jsonWorker = new KinoheldJsonWorker();
            m_client = new KinoheldApiClient();
        }

        public KinoheldClient(
            IKinoheldApiClient client,
            IKinoheldJsonWorker jsonWorker)
        {
            m_client = client ?? throw new ArgumentNullException(nameof(client));
            m_jsonWorker = jsonWorker ?? throw new ArgumentNullException(nameof(jsonWorker));
        }

        public async Task<IEnumerable<Cinema>> GetCinemas(
            string city, 
            string searchTerm = "",
            int distance = 15, 
            GetCinemasDynamicQuery dynamicQuery = GetCinemasDynamicQuery.Full,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var jsonResult = await m_client.GetCinemas(city, searchTerm, distance, dynamicQuery, cancellationToken).ConfigureAwait(false);
            if (jsonResult == null)
            {
                return new Cinema[0];
            }

            var cinemas = m_jsonWorker.ConvertToCinemas(jsonResult);
            return FilterByDistance(cinemas, dynamicQuery);
        }

        private static IEnumerable<Cinema> FilterByDistance(
            IEnumerable<Cinema> cinemas,
            GetCinemasDynamicQuery dynamicQuery)
        {
            if (dynamicQuery != GetCinemasDynamicQuery.Full)
            {
                return cinemas;
            }

            // Hack:
            // The api is returning random cinemas with distance = null,
            // when searching for a non-existing city
            return cinemas.Where(p => p.Distance.HasValue);
        }

        public async Task<IEnumerable<Show>> GetShows(
            long cinemaId, 
            DateTime? date = null, 
            GetShowsDynamicQuery dynamicQuery = GetShowsDynamicQuery.Full, 
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var jsonResult = await m_client.GetShows(cinemaId, date, dynamicQuery, cancellationToken).ConfigureAwait(false);
            if (jsonResult == null)
            {
                return new Show[0];
            }

            return m_jsonWorker.ConvertToShows(jsonResult);
        }

        public async Task<CitySearchResult> GetCities(
            string searchTerm, 
            int limit = 10, 
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var jsonResult = await m_client.GetCities(searchTerm, limit, cancellationToken).ConfigureAwait(false);
            if (jsonResult == null)
            {
                return new CitySearchResult();
            }

            return m_jsonWorker.ConvertToCitySearchResult(jsonResult);
        }
    }
}