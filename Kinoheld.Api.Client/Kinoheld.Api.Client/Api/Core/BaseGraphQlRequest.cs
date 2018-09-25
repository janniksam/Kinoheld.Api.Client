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
            var queryResponsePart = QueryDynamicResponsePart();
            if (string.IsNullOrEmpty(queryResponsePart))
            {
                return Query();
            }

            return Query()?.Replace(DynamicWildcard, queryResponsePart);
        }

        protected abstract string Query();

        protected abstract string QueryDynamicResponsePart();

        protected abstract dynamic Parameters();

        protected abstract string OperationName();
    }
}