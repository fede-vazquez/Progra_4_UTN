using Auth.Config;
using Auth.Repositories;
using Auth.Services;
using Auth.Utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opts =>
{
    opts.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Auth API",
        Description = "An ASP.NET Core Web Api for managing Auth"
    });
    opts.AddSecurityDefinition("Token", new OpenApiSecurityScheme
    {
        BearerFormat = "JWT",
        Description = "JWL Authorization header using the Bearer Scheme.",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Name = "Authorization",
        Scheme = "bearer"
    });

    opts.OperationFilter<AuthOperationFilter>();
});

// Services
builder.Services.AddScoped<UserServices>();
builder.Services.AddScoped<AuthServices>();
builder.Services.AddScoped<RoleServices>();
builder.Services.AddScoped<IEncoderServices, EncoderServices>();

// Repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRoleRespository, RoleRepository>();

builder.Services.AddAutoMapper(opts => { }, typeof(Mapping));

builder.Services.AddDbContext<ApplicationDbContext>(opts =>
{
    opts.UseSqlServer(builder.Configuration.GetConnectionString("authConnection"));
});

// JWT
var secret = builder.Configuration.GetSection("Secrets:JWT")?.Value?.ToString() ?? string.Empty;
var key = Encoding.UTF8.GetBytes(secret);
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(opts =>
    {
        opts.SaveToken = true;
        opts.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true
        };
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
