using backend.Controllers;

namespace backend.Routes;

public static class StockMovementRoutes
{
    public static void MapStockMovementEndpoints(this IEndpointRouteBuilder app)
    {
       //prefij
        var group = app.MapGroup("/api/products/{productId}/movements").RequireAuthorization();

        group.MapGet("/", StockMovementsController.GetMovements);
        group.MapPost("/", StockMovementsController.RegisterMovement);
    }
}