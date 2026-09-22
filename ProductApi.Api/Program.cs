using Microsoft.EntityFrameworkCore;
using ProductApi.Application.Interfaces;
using ProductApi.Application.Services;
using ProductApi.Infrastructure.Data;
using ProductApi.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddOpenApi();

var connectionString =
    builder.Configuration.GetConnectionString(
        "DefaultConnection");

builder.Services.AddDbContext<ProductDbContext>(
    options =>
        options.UseSqlServer(connectionString));

builder.Services.AddScoped<
    IProductRepository,
    ProductRepository>();

builder.Services.AddScoped<ProductService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint(
            "/openapi/v1.json",
            "Product API v1");
    });
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();