using Microsoft.EntityFrameworkCore;
using backend.Data;
using backend.Routes;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

//RegisterRoutes of Products
app.MapProductEndPoints();
//RegisterRoutes of Movements
app.MapStockMovementEndpoints();

app.Run();