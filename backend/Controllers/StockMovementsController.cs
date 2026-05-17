using System.Security.Cryptography.X509Certificates;
using backend.Data;
using backend.DtOs;
using backend.DTOs;
using backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;

namespace backend.Controllers;

public static class StockMovementsController
{
    // GET: /api/products/{productId}/movements
    public static async Task<IResult> GetMovements(int productId, AppDbContext db)
    {
        //verification of product
        var productExists = await db.Products.AnyAsync(p => p.Id == productId);
        if (!productExists) return Results.NotFound("Producto no encontrado.");

        var movements = await db.StockMovements
            .Include(m => m.Product)
            .Where(m => m.ProductId == productId)
            .OrderByDescending(m => m.TimeStamp)
            .ToListAsync();
        
        return Results.Ok(movements);
    }

    // POST: /api/products/{productId}/movements

    public static async Task<IResult>RegisterMovement(int productId, CreateStockMovementDto dto, AppDbContext db)
    {
        var product = await db.Products.FindAsync(productId);
        if (product is null) return Results.NotFound("Producto no encontrado");

        //validator of inventory negative
        if (dto.Type == MovementType.Outbound)
        {
            if(product.QuantityInStock < dto.Quantity)
            {
                return Results.BadRequest(new{
                    Error = "Stock insuficiente",
                    CurrentDbContext = product.QuantityInStock,
                    Requested = dto.Quantity  
                });
            }

            product.QuantityInStock -= dto.Quantity;
        }
        else if (dto.Type == MovementType.Inbound)
        {
            product.QuantityInStock += dto.Quantity;
        }

        var movement = new StockMovement
        {
            ProductId = productId,
            Type = dto.Type,
            Quantity = dto.Quantity,
            Reason = dto.Reason,
            TimeStamp = DateTime.UtcNow
        };

        db.StockMovements.Add(movement);

        await db.SaveChangesAsync();

        return Results.Created($"/api/products/{productId}/movements/{movement.Id}", movement);
    }
}