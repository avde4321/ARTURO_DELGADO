using BD.Interfaces;
using BD.Models;
using BD.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<PruebaAlmarContext>(opciones =>
opciones.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<LoginInterface, LoginServices>();
builder.Services.AddScoped<DetalleInterface, DetalleServices>();

var app = builder.Build();

//Descomentar para crear las base
/*using(var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<PruebaAlmarContext>();
    context.Database.Migrate();
}*/

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
