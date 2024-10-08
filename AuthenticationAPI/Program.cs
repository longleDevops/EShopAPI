using System.Text;
using ApplicationCore.IServices;
using AuthenticationAPI.Data;
using AuthenticationAPI.Entities;
using AuthenticationAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IAuthenticationServices<ApplicationUser>, AuthenticationService>();

builder.Services.AddControllers();



builder.Services.AddDbContext<AuthenticationDbContext>(options =>
{
     // options.UseSqlServer(builder.Configuration.GetConnectionString("EShopDbConnection"));
    options.UseSqlServer(Environment.GetEnvironmentVariable("EShopDbConnection"));
});

// Identity
builder.Services.AddIdentity<ApplicationUser, Role>()
    .AddEntityFrameworkStores<AuthenticationDbContext>()
    .AddDefaultTokenProviders();

// Adding Authentication
builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    })



    // Adding Jwt Bearer
    .AddJwtBearer(options =>
    {
        options.SaveToken = true;
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidAudience = Environment.GetEnvironmentVariable("JWT_ValidAudience"),
            ValidIssuer =  Environment.GetEnvironmentVariable("JWT_ValidIssuer"),
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("JWT:Secret")))
        };
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireAdministratorRole",
        policy => policy.RequireRole("Admin"));
});

// CORS policy
// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularDevClient",
        b =>
        {
            b
                .WithOrigins("http://localhost:4200", "https://mango-rock-0b437651e.5.azurestaticapps.net")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

var app = builder.Build();
app.UseCors("AllowAngularDevClient");
// Configure the HTTP request pipeline.

    app.UseSwagger();
    app.UseSwaggerUI();


app.UseHttpsRedirection();

// Authentication
app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();

