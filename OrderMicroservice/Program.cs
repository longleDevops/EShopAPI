﻿using Infrastructure.Implementation.Service;
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


builder.Services.AddDbContext<EShopDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("EShopDbConnection"));
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();


app.UseAuthorization();

app.MapControllers();

app.Run();

