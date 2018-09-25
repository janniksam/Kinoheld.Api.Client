using Kinoheld.Api.Client.Api.Core;

namespace Kinoheld.Api.Client.Api.Queries
{
    public class GetCitiesQuery : BaseGraphQlRequest
    {
        private readonly string m_searchTerm;
        private readonly int m_limit;

        public GetCitiesQuery(string searchTerm, int limit)
        {
            m_searchTerm = searchTerm;
            m_limit = limit;
        }

        protected override string QueryDynamic()
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

        protected override string QueryPartFullResponse()
        {
            return null;
        }

        protected override string OperationName()
        {
            return "SearchCities";
        }

        protected override dynamic Parameters()
        {
            return new
            {
                searchTerm = m_searchTerm,
                limit = m_limit
            };
        }

    }
}