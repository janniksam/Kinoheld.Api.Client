using System;
using System.Collections.Generic;
using System.Text;
using Kinoheld.Api.Client.Api.Core;
using Kinoheld.Api.Client.Requests;

namespace Kinoheld.Api.Client.Api.Queries
{
    public class GetShowsQuery : BaseGraphQlRequest
    {
        private readonly int m_cinemaId;
        private readonly DateTime? m_date;
        private readonly GetShowsDynamicQuery m_dynamicQuery;

        public GetShowsQuery(int cinemaId, DateTime? date, GetShowsDynamicQuery dynamicQuery)
        {
            m_cinemaId = cinemaId;
            m_date = date;
            m_dynamicQuery = dynamicQuery;
        }

        protected override string Query()
        {
            return @"
query SearchShow($cinemaId: ID!, $date: String!) {
  shows (cinemaId: $cinemaId, date: $date) {
#DYNAMIC
        }
    }";
        }

        protected override string QueryDynamicResponsePart()
        {
            if (m_dynamicQuery == GetShowsDynamicQuery.Full)
            {
                return QueryPartFullResponse();
            }

            var builder = new StringBuilder();
            if (m_dynamicQuery.HasFlag(GetShowsDynamicQuery.Name))
            {
                builder.AppendLine("            name");
            }

            if (m_dynamicQuery.HasFlag(GetShowsDynamicQuery.Beginning))
            {
                builder.AppendLine("            beginning {");
                builder.AppendLine("                formatted");
                builder.AppendLine("            }");
            }

            if (m_dynamicQuery.HasFlag(GetShowsDynamicQuery.Flags))
            {
                builder.AppendLine("            flags {");
                builder.AppendLine("                name");
                builder.AppendLine("            }");
            }

            if (m_dynamicQuery.HasFlag(GetShowsDynamicQuery.DetailUrl))
            {
                builder.AppendLine("            detailUrl {");
                builder.AppendLine("                absoluteUrl");
                builder.AppendLine("            }");
            }

            if (m_dynamicQuery.HasFlag(GetShowsDynamicQuery.MovieInfo))
            {
                builder.AppendLine("            movie {");
                builder.AppendLine("                id");
                builder.AppendLine("                title");
                builder.AppendLine("                genres {");
                builder.AppendLine("                    name");
                builder.AppendLine("                }");
                builder.AppendLine("            }");
            }

            return builder.ToString();
        }

        private string QueryPartFullResponse()
        {
            var builder = new StringBuilder();
            builder.AppendLine("            name");
            builder.AppendLine("            beginning {");
            builder.AppendLine("                formatted");
            builder.AppendLine("            }");
            builder.AppendLine("            flags {");
            builder.AppendLine("                name");
            builder.AppendLine("            }");
            builder.AppendLine("            detailUrl {");
            builder.AppendLine("                absoluteUrl");
            builder.AppendLine("            }");
            builder.AppendLine("            movie {");
            builder.AppendLine("                id");
            builder.AppendLine("                title");
            builder.AppendLine("                genres {");
            builder.AppendLine("                    name");
            builder.AppendLine("                }");
            builder.AppendLine("            }");
            return builder.ToString();
        }

        protected override string OperationName()
        {
            return "SearchShow";
        }

        protected override dynamic Parameters()
        {
            return new
            {
                cinemaId = m_cinemaId,
                date = m_date?.ToShortDateString() ?? string.Empty
            };
        }

    }
}