using GraphQL.Common.Request;

namespace Kinoheld.Api.Client.Api.Core
{
    public abstract class BaseGraphQlRequest : IGraphQlQuery
    {
        private const string DynamicWildcard = "#DYNAMIC";

        public GraphQLRequest BuildRequest()
        {
            return new GraphQLRequest
            {
                Query = FormatQuery(),
                OperationName = OperationName(),
                Variables = Parameters()
            };
        }

        private string FormatQuery()
        {
            var queryPartFullResponse = QueryPartFullResponse();
            if (string.IsNullOrEmpty(queryPartFullResponse))
            {
                return QueryDynamic();
            }

            return QueryDynamic()?.Replace(DynamicWildcard, QueryPartFullResponse());
        }

        protected abstract string QueryDynamic();

        protected abstract string QueryPartFullResponse();

        protected abstract dynamic Parameters();

        protected abstract string OperationName();
    }
}