using Kinoheld.Api.Client.Api.Core;

namespace Kinoheld.Api.Client.Api.Queries
{
    public class GetCinemasQuery : BaseGraphQlRequest
    {
        private readonly string m_searchTerm;
        private readonly string m_city;
        private readonly int m_distance;

        public GetCinemasQuery(string searchTerm, string city, int distance)
        {
            m_searchTerm = searchTerm;
            m_city = city;
            m_distance = distance;
        }

        protected override string QueryDynamic()
        {
            return @"
query CinemaSearch($searchTerm: String!, $location: String, $distance: Int) {
  cinemas (search: $searchTerm, location: $location, distance: $distance) {
       #DYNAMIC
    }
}";
        }

        protected override string QueryPartFullResponse()
        {
            return @"
            id
            name
            street
            city
            {
                name
            }
            distance
            detailUrl
            {
                absoluteUrl
            }";
        }

        protected override string OperationName()
        {
            return "CinemaSearch";
        }

        protected override dynamic Parameters()
        {
            return new
            {
                searchTerm = m_searchTerm,
                location = m_city,
                distance = m_distance
            };
        }

    }
}