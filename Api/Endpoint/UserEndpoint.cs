using tunetribe.Api.Arguments;
using tunetribe.Api.Queries;
using tunetribe.Core.Model;

namespace tunetribe.Api.Endpoint;

public class UserEndpoint : IAsyncEndpoint<NoArguments, User[]>
{
    private readonly GetAllUsersQuery _getAllUsersQuery;
    private readonly AddUserQuery _addUserQuery;
    
    public UserEndpoint(
        GetAllUsersQuery getAllUsersQuery,
        AddUserQuery addUserQuery)
    {
        _getAllUsersQuery = getAllUsersQuery;
        _addUserQuery = addUserQuery;
    }

    public Task<User[]> GetAsync(NoArguments arguments) => _getAllUsersQuery.Execute(arguments);

    public Task<bool> PostAsync(AddUserArguments arguments) => _addUserQuery.Execute(arguments);
}