using Microsoft.EntityFrameworkCore;
using ProductAPI.ApplicationCore.Contracts.Repositories;
using ProductAPI.ApplicationCore.Contracts.Services;
using ProductAPI.Infrastructure.Data;
using ProductAPI.Infrastructure.Repositories;
using ProductAPI.Infrastructure.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// repositories
builder.Services.AddScoped<IProductRepository, ProductRepository>();

// services
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddDbContext<EShopDbContext>(options =>
{
     options.UseSqlServer(builder.Configuration.GetConnectionString("EShopDbConnection"));
     // options.UseSqlServer(Environment.GetEnvironmentVariable("EShopDbConnection"));
});

// CORS policy
// Add CORS policy
builder.Services.AddCors(options =>
{
     options.AddPolicy("AllowAngularDevClient",
          b =>
          {
               b
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
          });
});
var app = builder.Build();


// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

// Use CORS
app.UseCors("AllowAngularDevClient");

app.UseAuthorization();

app.MapControllers();

app.Run();

