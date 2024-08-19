using Infrastructure.Implementation.Service;
using ProductAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using OrderAPI.ApplicationCore.Contracts.Repositories;
using OrderAPI.Infrastructure.Repositories;
using OrderAPI.ApplicationCore.Contracts.Services;
using OrderAPI.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Repository
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();


// Services
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IRabbitMqProducerConsumer, RabitMqProducerConsumer>();

// Add Cors policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularDevClient", builder =>
        {
            builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        }
    );
});
builder.Services.AddDbContext<EShopDbContext>(options =>
{
    // options.UseSqlServer(builder.Configuration.GetConnectionString("EShopDbConnection"));
     options.UseSqlServer(Environment.GetEnvironmentVariable("EShopDbConnection"));
});

var app = builder.Build();
app.UseCors("AllowAngularDevClient");

app.UseSwagger();
app.UseSwaggerUI();


app.UseAuthorization();

app.MapControllers();

app.Run();

