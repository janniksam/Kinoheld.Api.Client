using System;

namespace Kinoheld.Api.Client.Api.Queries
{
    public class GetShowsQuery
    {
        public static string Query()
        {
            return @"
query SearchShow($cinemaId: ID!, $date: String!) {
  shows (cinemaId: $cinemaId, date: $date) {
            name
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
            }
        }
    }";
        }

        public static string OperationName()
        {
            return "shows";
        }

        public static dynamic Parameters(int cinemaId, DateTime? date)
        {
            return new
            {
                cinemaId = cinemaId,
                date = date?.ToShortDateString() ?? string.Empty
            };
        }

    }
}