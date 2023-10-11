using Npgsql;

namespace tunetribe.Api.Database.Interfaces;

public interface IDatabaseDriver
{
    public IAsyncEnumerable<TResult> Read<TResult>(string query, IEnumerable<NpgsqlParameter>? parameters, IDataMapper<TResult> dataMapper);

    public Task Cancel();
}