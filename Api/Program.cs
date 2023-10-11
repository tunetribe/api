using tunetribe.Api;

var builder = WebApplication.CreateBuilder(args);
Services.InitServices(builder);

var app = builder.Build();
Router.InitRoutes(app);

await app.RunAsync();