using tunetribe.Api.Endpoint;

namespace tunetribe.Api;

public static class Router
{
    public static void InitRoutes(WebApplication app)
    {
        SetDefaultRoute(app);
        SetUserRoute(app);
        SetAuthenticationRoute(app);
    }

    private static void SetDefaultRoute(WebApplication app) => app.MapGet(
        "/",
        () => "Hello World!");
    
    private static void SetUserRoute(WebApplication app) => app.MapGet(
        "/users", 
        (UserEndpoint endpoint) => endpoint.GetAsync(new()));
    
    private static void SetAuthenticationRoute(WebApplication app) => app.MapGet(
        "/auth/{username}/{password}", 
        (AuthenticationEndpoint endpoint, string username, string password) => endpoint.GetAsync(new(username, password)));

}