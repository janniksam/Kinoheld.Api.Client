using GraphQL.Common.Request;

namespace Kinoheld.Api.Client.Api.Core
{
    public abstract class BaseGraphQlRequest : IGraphQlQuery
    {
        public GraphQLRequest BuildRequest()
        {
            return new GraphQLRequest
            {
                Query = Query(),
                OperationName = OperationName(),
                Variables = Parameters()
            };
        }

        protected abstract dynamic Parameters();

        protected abstract string OperationName();

        protected abstract string Query();
    }
}