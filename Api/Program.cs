using tunetribe.Api;

await WebApplication.CreateBuilder(args)
    .RegisterServices()
    .Build()
    .MapRoutes()
    .RunAsync();

