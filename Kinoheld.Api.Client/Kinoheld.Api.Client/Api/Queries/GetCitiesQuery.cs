using System;

namespace Kinoheld.Api.Client.Api.Queries
{
    public class GetCitiesQuery
    {
        public static string Query()
        {
            return @"
query SearchCities($searchTerm: String!, $limit: Int) {
   cities(search: $searchTerm, limit: $limit) {
     name
     detailUrl
     {              
         relativeUrl
     }
   }          
   postcodes(search: $searchTerm, limit: $limit) {
            postcode
            city {
              name
              detailUrl 
              {
                relativeUrl
              }  
          }  
   }    
}";
        }

        public static string OperationName()
        {
            return "SearchCities";
        }

        public static dynamic Parameters(string searchTerm, int limit)
        {
            return new
            {
                searchTerm = searchTerm,
                limit = limit
            };
        }

    }
}