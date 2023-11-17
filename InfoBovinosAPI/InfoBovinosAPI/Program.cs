using FluentValidation;
using InfoBovinosAPI.Data;
using InfoBovinosAPI.DTOs;
using InfoBovinosAPI.Helpers;
using InfoBovinosAPI.Interfaces;
using InfoBovinosAPI.Mappers;
using InfoBovinosAPI.Models;
using InfoBovinosAPI.Repository;
using InfoBovinosAPI.Validators;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddTransient<IValidator<AnimalDTO>, AnimalValidator>();
builder.Services.AddTransient<IValidator<RazaDTO>, RazaValidator>();
builder.Services.AddScoped<IAnimalRepository, AnimalRepository>();
builder.Services.AddScoped<IRazaRepository, RazaRepository>();
builder.Services.AddScoped<IAnimalRazaRepository, AnimalRazaRepository>();
builder.Services.AddScoped<AnimalMapper>();
builder.Services.AddScoped<RazaMapper>();
builder.Services.AddScoped<RazaAssociationChecker>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlite("Data Source = bovinosdb.db");
});

var app = builder.Build();

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
