using backend.Controllers;

namespace backend.Routes;

public static class AuthRoutes
{
    public static void MapAuthEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/auth");

        group.MapPost("/register", AuthController.Register);
        group.MapPost("/login", AuthController.Login);
    }
}