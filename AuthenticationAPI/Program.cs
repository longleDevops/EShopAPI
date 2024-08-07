using ApplicationCore.IServices;
using AuthenticationAPI.Data;
using AuthenticationAPI.Entities;
using AuthenticationAPI.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IAuthenticationServices<ApplicationUser>, AuthenticationService>();

builder.Services.AddControllers();



builder.Services.AddDbContext<AuthenticationDbContext>(options =>
{
     options.UseSqlServer(builder.Configuration.GetConnectionString("EShopDbConnection"));
    // options.UseSqlServer(Environment.GetEnvironmentVariable("EShopDbConnection"));
});

// Identity
builder.Services.AddIdentity<ApplicationUser, Role>()
    .AddEntityFrameworkStores<AuthenticationDbContext>()
    .AddDefaultTokenProviders();



var app = builder.Build();

// Configure the HTTP request pipeline.

    app.UseSwagger();
    app.UseSwaggerUI();


app.UseHttpsRedirection();

// Authentication
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

