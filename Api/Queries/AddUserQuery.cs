using Npgsql;
using tunetribe.Api.Arguments;
using tunetribe.Api.Database.Interfaces;
using tunetribe.Api.Mapper;
using tunetribe.Core.Model;

namespace tunetribe.Api.Queries;

public class AddUserQuery : IQuery<AddUserArguments, bool>
{
    private IDatabaseDriver _driver;
    private IDatabaseConfiguration _configuration;
    private StatementMapper _mapper;
    private static string _query = "addUser(@username, @password_hash)";

    public AddUserQuery(
        IDatabaseDriver driver,
        IDatabaseConfiguration configuration,
        StatementMapper mapper)
    {
        _driver = driver;
        _configuration = configuration;
        _mapper = mapper;
    }

    public async Task<bool> Execute(AddUserArguments arguments)
    {
        var parameters = CreateParameters(arguments);

        await foreach (var entry in _driver.Read(_query, parameters, _mapper))
        {
            return entry;
        }

        return false;
    }

    public IEnumerable<NpgsqlParameter> CreateParameters(AddUserArguments arguments)
    {
        yield return new("username", arguments.Username);
        yield return new("password_hash", arguments.PasswordHash);
    }

}