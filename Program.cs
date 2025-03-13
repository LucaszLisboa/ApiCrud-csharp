using ApiCrud.Data;
using ApiCrud.Domain.Services;
using ApiCrud.Services;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IEstudanteService, EstudanteService>();
builder.Services.AddScoped<EstudanteRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapScalarApiReference(); // scalar/v1
    app.MapOpenApi();
}

app.UseHttpsRedirection();


app.MapControllers();

// Abrir Scalar no navegador
app.Lifetime.ApplicationStarted.Register(() =>
{
    Process.Start(new ProcessStartInfo("https://localhost:7269/scalar/v1") { UseShellExecute = true });
});

app.Run();
