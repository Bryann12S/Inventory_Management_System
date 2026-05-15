using backend.Data;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers;  

public class ProductsController
{

    //GET: Profuct list with filters
    public static async Task<IResult> GetProducts(string? category, int? lowStockThreshold, AppDbContext db)
    {
        var query = db.Products.AsQueryable();

        if (!string.IsNullOrWhiteSpace(category))
            query = query.Where(p => p.Category.ToLower() == category.ToLower());

        if (lowStockThreshold.HasValue)
            query = query.Where(p => p.QuantityInStock < lowStockThreshold.Value);

        return Results.Ok(await query.ToListAsync());
    }

    //GET: Products for ID
    public static async Task<IResult> GetProduct(int id, AppDbContext db)
    {
        var product = await db.Products.FindAsync(id);
        return product is not null ? Results.Ok(product) : Results.NotFound();
    }

    //POST: Create Product
    public static async Task<IResult> CreateProduct(Product product, AppDbContext db)
    {
        db.Products.Add(product);
        await db.SaveChangesAsync();
        return Results.Created($"api/products/{product.Id}", product);
    }

    //PUT: Update Preoduct
    public static async Task<IResult> UpdateProduct (int id, Product inputProduct, AppDbContext db)
    {
        if (id != inputProduct.Id) return Results.BadRequest("El ID no coincide.");

        var product = await db.Products.FindAsync(id);
        if (product is null) return Results.NotFound();

        product.Name = inputProduct.Name;
        product.SKU = inputProduct.SKU;
        product.Category = inputProduct.Category;
        product.QuantityInStock = inputProduct.QuantityInStock;
        product.UnitPrice = inputProduct.UnitPrice;

        await db.SaveChangesAsync();
        return Results.NoContent();
    }

    //DETELE: Delete Products
    public static async Task<IResult> DeleteProduct (int id, AppDbContext db)
    {
        var product = await db.Products.FindAsync(id);
        if (product is null) return Results.NotFound();

        db.Products.Remove(product);
        await db.SaveChangesAsync();
        return Results.NoContent();
    }

}