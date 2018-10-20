using System;
using System.Threading;
using System.Threading.Tasks;
using GraphQL.Common.Request;
using GraphQL.Common.Response;
using Kinoheld.Api.Client.Api.Queries;
using Kinoheld.Api.Client.Helper;
using Kinoheld.Api.Client.Requests;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using RestSharp;

namespace Kinoheld.Api.Client.Api
{
    internal class KinoheldApiClient : IKinoheldApiClient
    {
        private const string KinoheldEndpoint = "https://graph.kinoheld.de/graphql/v1/query";
        private const string ResponseTypeApplicationJson = "application/json";

        public async Task<JObject> GetCinemas(string city, string searchTerm, int distance,
            GetCinemasDynamicQuery dynamicQuery, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(city?.Trim()))
            {
                throw new ArgumentNullException(nameof(city));
            }

            if (distance <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(distance),
                    $"{nameof(distance)} needs to be bigger than 0");
            }

            var query = new GetCinemasQuery(searchTerm, city, distance, dynamicQuery);
            var request = BuildRestRequest(query.BuildRequest());
            var client = CreateClient();
            var response = await client.ExecutePostTaskAsync<GraphQLResponse>(request, cancellationToken).ConfigureAwait(false);
            return response?.Data?.Data;
        }

        public async Task<JObject> GetShows(long cinemaId, DateTime? date, GetShowsDynamicQuery dynamicQuery, CancellationToken cancellationToken)
        {
            if (cinemaId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(cinemaId), $"{nameof(cinemaId)} needs to be bigger than 0");
            }

            var query = new GetShowsQuery(cinemaId, date, dynamicQuery);
            var request = BuildRestRequest(query.BuildRequest());
            var client = CreateClient();
            var response = await client.ExecutePostTaskAsync<GraphQLResponse>(request, cancellationToken).ConfigureAwait(false);
            return response?.Data?.Data;
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

            var query = new GetCitiesQuery(searchTerm, limit);
            var request = BuildRestRequest(query.BuildRequest());
            var client = CreateClient();
            var response = await client.ExecutePostTaskAsync<GraphQLResponse>(request, cancellationToken).ConfigureAwait(false);
            return response?.Data?.Data;
        }

        private RestRequest BuildRestRequest(GraphQLRequest request)
        {
            var serializedRequest = JsonConvert.SerializeObject(request, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });

            var restRequest = new RestRequest
            {
                Method = Method.POST
            };
            restRequest.AddHeader("Accept", ResponseTypeApplicationJson);
            restRequest.Parameters.Clear();
            restRequest.AddParameter(ResponseTypeApplicationJson, serializedRequest, ParameterType.RequestBody);
            return restRequest;
        }

        private RestClient CreateClient()
        {
            var client = new RestClient(KinoheldEndpoint);
            client.AddHandler(ResponseTypeApplicationJson, NewtonsoftJsonSerializer.Default);
            return client;
        }
    }
}