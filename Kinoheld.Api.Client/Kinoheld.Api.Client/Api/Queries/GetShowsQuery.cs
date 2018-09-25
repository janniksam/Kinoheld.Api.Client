using System;
using System.Collections.Generic;
using Kinoheld.Api.Client.Api.Core;

namespace Kinoheld.Api.Client.Api.Queries
{
    public class GetShowsQuery : BaseGraphQlRequest
    {
        private readonly int m_cinemaId;
        private readonly DateTime? m_date;

        public GetShowsQuery(int cinemaId, DateTime? date)
        {
            m_cinemaId = cinemaId;
            m_date = date;
        }

        protected override string QueryDynamic()
        {
            return @"
query SearchShow($cinemaId: ID!, $date: String!) {
  shows (cinemaId: $cinemaId, date: $date) {
#DYNAMIC
        }
    }";
        }

        protected override string QueryPartFullResponse()
        {
            return @"            name
            beginning {
                formatted
            }
            flags {
                name
            }
            detailUrl {
                absoluteUrl
            }
            movie {
                genres {
                    name
                }
            }";
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