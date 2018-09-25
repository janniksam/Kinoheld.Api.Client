using System.Text;
using Kinoheld.Api.Client.Api.Core;
using Kinoheld.Api.Client.Requests;

namespace Kinoheld.Api.Client.Api.Queries
{
    public class GetCinemasQuery : BaseGraphQlRequest
    {
        private readonly string m_searchTerm;
        private readonly string m_city;
        private readonly int m_distance;
        private readonly GetCinemasDynamicQuery m_dynamicQuery;

        public GetCinemasQuery(string searchTerm, string city, int distance, GetCinemasDynamicQuery dynamicQuery)
        {
            m_searchTerm = searchTerm;
            m_city = city;
            m_distance = distance;
            m_dynamicQuery = dynamicQuery;
        }

        protected override string Query()
        {
            return @"
query CinemaSearch($searchTerm: String!, $location: String, $distance: Int) {
  cinemas (search: $searchTerm, location: $location, distance: $distance) {
       #DYNAMIC
    }
}";
        }

        protected override string QueryDynamicResponsePart()
        {
            if (m_dynamicQuery == GetCinemasDynamicQuery.Full)
            {
                return QueryPartFullResponse();
            }

            var builder = new StringBuilder();
            if (m_dynamicQuery.HasFlag(GetCinemasDynamicQuery.Id))
            {
                builder.AppendLine("            id");
            }

            if (m_dynamicQuery.HasFlag(GetCinemasDynamicQuery.Name))
            {
                builder.AppendLine("            name");
            }

            if (m_dynamicQuery.HasFlag(GetCinemasDynamicQuery.Street))
            {
                builder.AppendLine("            street");
            }

            if (m_dynamicQuery.HasFlag(GetCinemasDynamicQuery.City))
            {
                builder.AppendLine("            city {");
                builder.AppendLine("                name");
                builder.AppendLine("            }");
            }

            if (m_dynamicQuery.HasFlag(GetCinemasDynamicQuery.Distance))
            {
                builder.AppendLine("            distance");
            }

            if (m_dynamicQuery.HasFlag(GetCinemasDynamicQuery.DetailUrl))
            {
                builder.AppendLine("            detailUrl {");
                builder.AppendLine("                absoluteUrl");
                builder.AppendLine("            }");
            }

            return builder.ToString();
        }

        private string QueryPartFullResponse()
        {
            var builder = new StringBuilder();
            builder.AppendLine("            id");
            builder.AppendLine("            name");
            builder.AppendLine("            street");
            builder.AppendLine("            city {");
            builder.AppendLine("                name");
            builder.AppendLine("            }");
            builder.AppendLine("            distance");
            builder.AppendLine("            detailUrl {");
            builder.AppendLine("                absoluteUrl");
            builder.AppendLine("            }");
            return builder.ToString();
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