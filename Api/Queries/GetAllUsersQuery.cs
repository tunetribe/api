using tunetribe.Api.Arguments;
using tunetribe.Api.Database.Interfaces;
using tunetribe.Core.Model;

namespace tunetribe.Api.Queries;

public class GetAllUsersQuery : IQuery<NoArguments, User[]>
{
    private IDatabaseDriver _driver;
    private IDatabaseConfiguration _configuration;
    private IDataMapper<User> _mapper;
    private string _query;
    
    public GetAllUsersQuery(IDatabaseDriver driver, IDatabaseConfiguration configuration, IDataMapper<User> mapper)
    {
        _driver = driver;
        _configuration = configuration;
        _mapper = mapper;
        _query = $"""
            select 
                id,
                username,
                password_hash
            from 
                {configuration.Schema}.users
            """;
    }
    
    public async Task<User[]> Execute(NoArguments arguments)
    {
        var users = new List<User>();

        await foreach (var user in _driver.Read(_query, null, _mapper))
        {
            users.Add(user);
        }

        return users.ToArray();
    }

}