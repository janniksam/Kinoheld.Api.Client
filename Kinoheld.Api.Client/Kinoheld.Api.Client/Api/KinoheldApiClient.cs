using System;
using System.Threading;
using System.Threading.Tasks;
using GraphQL.Client;
using Kinoheld.Api.Client.Api.Queries;
using Kinoheld.Api.Client.Requests;
using Newtonsoft.Json.Linq;

namespace Kinoheld.Api.Client.Api
{
    internal class KinoheldApiClient : IKinoheldApiClient
    {
        private const string KinoheldEndpoint = "https://graph.kinoheld.de/graphql/v1/query";

        public async Task<JObject> GetCinemas(string city, string searchTerm, int distance, GetCinemasDynamicQuery dynamicQuery, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(city?.Trim()))
            {
                throw new ArgumentNullException(nameof(city));
            }

            if (distance <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(distance), $"{nameof(distance)} needs to be bigger than 0");
            }

            using (var client = GetClient())
            {
                var query = new GetCinemasQuery(searchTerm, city, distance, dynamicQuery);
                var response = await client.PostAsync(query.BuildRequest(), cancellationToken).ConfigureAwait(false);
                return response?.Data;
            }
        }

        public async Task<JObject> GetShows(long cinemaId, DateTime? date, GetShowsDynamicQuery dynamicQuery, CancellationToken cancellationToken)
        {
            if (cinemaId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(cinemaId), $"{nameof(cinemaId)} needs to be bigger than 0");
            }

            using (var client = GetClient())
            {
                var query = new GetShowsQuery(cinemaId, date, dynamicQuery);
                var response = await client.PostAsync(query.BuildRequest(), cancellationToken).ConfigureAwait(false);
                return response?.Data;
            }
        }

        public async Task<JObject> GetCities(string searchTerm, int limit, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(searchTerm?.Trim()))
            {
                throw new ArgumentNullException(nameof(searchTerm));
            }

            if (limit <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(limit), $"{nameof(limit)} needs to be bigger than 0");
            }

            using (var client = GetClient())
            {
                var query = new GetCitiesQuery(searchTerm, limit);
                var response = await client.PostAsync(query.BuildRequest(), cancellationToken).ConfigureAwait(false);
                return response?.Data;
            }
        }

        private GraphQLClient GetClient()
        {
            return new GraphQLClient(KinoheldEndpoint);
        }
    }
}