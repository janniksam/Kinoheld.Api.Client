namespace Kinoheld.Api.Client.Api.Queries
{
    public class SearchCinemaQuery
    {
        public static string Query()
        {
            return @"
query CinemaSearch($searchTerm: String!, $location: String, $distance: Int) {
  cinemas (search: $searchTerm, location: $location, distance: $distance) {
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
        }
    }
}";
        }

        public static string OperationName()
        {
            return "cinemas";
        }

        public static dynamic Parameters(string searchTerm, string city, int distance)
        {
            return new
            {
                searchTerm = searchTerm,
                location = city,
                distance = distance
            };
        }

    }
}