using tunetribe.Api.Arguments;
using tunetribe.Api.Queries;

namespace tunetribe.Api.Endpoint;

public class AuthenticationEndpoint: IAsyncEndpoint<AuthenticationArguments, bool>
{
    private readonly AuthenticationQuery _query;
    
    public AuthenticationEndpoint(AuthenticationQuery query)
    {
        _query = query;
    }

    public Task<bool> GetAsync(AuthenticationArguments arguments) => _query.Execute(arguments);
    
}