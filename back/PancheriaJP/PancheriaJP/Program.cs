using Introduccion.Config;
using Introduccion.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PancheriaJP.Config;
using PancheriaJP.Repositories;
using PancheriaJP.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.InvalidModelStateResponseFactory = context =>
    {
        var errors = context.ModelState
        .Where(x => x.Value?.Errors.Count > 0)
        .ToDictionary(
            kvp => kvp.Key,
            kvp =>
                kvp.Value?.Errors.Select(e => e.ErrorMessage).ToArray()
                ?? Array.Empty<string>()
        );
        return new BadRequestObjectResult(new ValidationErrorResponse(errors));
    };
});

// Services
builder.Services.AddScoped<PanchoServices>();
builder.Services.AddScoped<IngredienteServices>();
builder.Services.AddScoped<CategoriaServices>();

//Repositories
builder.Services.AddScoped<IPanchoRepository, PanchoRepository>();
builder.Services.AddScoped<IIngredienteRepository, IngredienteRepository>();
builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();

// Mapper
builder.Services.AddAutoMapper(opts => { }, typeof(Mapping));

// DB
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("devConnection"));
});

var app = builder.Build();

app.UseCors(opts =>
{
    opts.AllowAnyMethod();
    opts.AllowAnyOrigin();
    opts.AllowAnyHeader();
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
