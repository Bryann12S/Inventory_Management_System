using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using backend.Models;

namespace backend.Data;

public class AppDbContext : IdentityDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext>options) : base(options)
    {
    }

    public DbSet<Product> products {get; set;}
    public DbSet<StockMovement> stockMovements {get; set;}
}