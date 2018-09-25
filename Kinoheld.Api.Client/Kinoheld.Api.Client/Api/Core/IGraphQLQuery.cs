using GraphQL.Common.Request;

namespace Kinoheld.Api.Client.Api.Core
{
    public interface IGraphQlQuery
    {
        GraphQLRequest BuildRequest();
    }
}