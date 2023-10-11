using tunetribe.Api.Arguments;
using tunetribe.Api.Queries;
using tunetribe.Core.Model;

namespace tunetribe.Api.Endpoint;

public class UserEndpoint : IAsyncEndpoint<NoArguments, User[]>
{
    private readonly GetAllUsersQuery _query;
    
    public UserEndpoint(GetAllUsersQuery query)
    {
        _query = query;
    }

    public Task<User[]> GetAsync(NoArguments arguments) => _query.Execute(arguments);
}