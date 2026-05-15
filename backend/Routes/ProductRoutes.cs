using backend.Controllers;

namespace backend.Routes;

public static class Productroutes
{
    public static void MapProductEndPoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/products");


        group.MapGet("/", ProductsController.GetProducts);
        group.MapGet("/{id}", ProductsController.GetProducts);
        group.MapPost("/", ProductsController.CreateProduct);
        group.MapPut("/{id}", ProductsController.UpdateProduct);
        group.MapDelete("/{id}", ProductsController.DeleteProduct);
    }
}