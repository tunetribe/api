using tunetribe.Api.Endpoint;

namespace tunetribe.Api;

public static class Router
{
    public static WebApplication MapRoutes(this WebApplication app)
    {
        SetDefaultRoute(app);
        SetUserGetRoute(app);
        SetUserPostRoute(app);
        SetAuthenticationRoute(app);

        return app;
    }

    private static void SetDefaultRoute(IEndpointRouteBuilder app) => app.MapGet(
        "/",
        () => "Hello World!");
    
    private static void SetUserGetRoute(IEndpointRouteBuilder app) => app.MapGet(
        "/users", 
        (UserEndpoint endpoint) => endpoint.GetAsync(new()));

    private static void SetUserPostRoute(IEndpointRouteBuilder app) => app.MapGet(
        "/users/{username}/{passwordHash}",
        (UserEndpoint endpoint, string username, string passwordHash) => endpoint.PostAsync(new(username, passwordHash)));
    
    private static void SetAuthenticationRoute(IEndpointRouteBuilder app) => app.MapGet(
        "/auth/{username}/{password}", 
        (AuthenticationEndpoint endpoint, string username, string password) => endpoint.GetAsync(new(username, password)));

}