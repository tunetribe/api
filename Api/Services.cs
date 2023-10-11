using Npgsql;
using tunetribe.Api.Configurations;
using tunetribe.Api.Database.Interfaces;
using tunetribe.Api.Database.Postgres;
using tunetribe.Api.Endpoint;
using tunetribe.Api.Mapper;
using tunetribe.Api.Queries;
using tunetribe.Core.Model;

namespace tunetribe.Api;

public static class Services
{
    public static void InitServices(WebApplicationBuilder builder)
    {
        InitDatabase(builder);
        InitDataMapper(builder);
        InitQueries(builder);
        InitEndpoints(builder);
    }

    private static void InitDatabase(WebApplicationBuilder builder)
    {
        InitDatabaseConfiguration(builder, "./Database/Postgres/PostgresConfiguration.json");
        builder.Services.AddTransient<IDatabaseDriver, PostgresDriver>();
    }

    private static void InitDatabaseConfiguration(WebApplicationBuilder builder, string path)
    {
        var configuration = new DatabaseConfiguration();
        builder.Configuration.AddJsonFile(path).Build();
        builder.Configuration.Bind(configuration);
        builder.Services.AddSingleton<IDatabaseConfiguration>(configuration);

        var dataSourceBuilder = new NpgsqlDataSourceBuilder(configuration.ConnectionString);
        // dataSourceBuilder.MapComposite<Choice>("choice");
        // dataSourceBuilder.MapComposite<Question>("question");
        builder.Services.AddSingleton<NpgsqlDataSource>(dataSourceBuilder.Build());
    }

    private static void InitDataMapper(WebApplicationBuilder builder)
    {
        builder.Services.AddSingleton<IDataMapper<User>, UserMapper>();
        builder.Services.AddSingleton<IDataMapper<bool>, BooleanMapper>();
        builder.Services.AddSingleton<IDataMapper<string>, StringMapper>();
    }
    
    private static void InitQueries(WebApplicationBuilder builder)
    {
        builder.Services.AddSingleton<GetAllUsersQuery>();
        builder.Services.AddSingleton<AuthenticationQuery>();
    }

    private static void InitEndpoints(WebApplicationBuilder builder)
    {
        builder.Services.AddSingleton<UserEndpoint>();
        builder.Services.AddSingleton<AuthenticationEndpoint>();
    }
}