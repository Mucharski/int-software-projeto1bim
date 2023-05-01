using System.Text.Json.Serialization;
using IntegracaoSistemasSoftwareTrabalho1BIM.Data;
using IntegracaoSistemasSoftwareTrabalho1BIM.Repositories;
using IntegracaoSistemasSoftwareTrabalho1BIM.Repositories.Interfaces;
using IntegracaoSistemasSoftwareTrabalho1BIM.Services;
using IntegracaoSistemasSoftwareTrabalho1BIM.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(x =>
    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles).AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Dependency Injection
builder.Services.AddScoped<IRestaurantService, RestaurantService>();
builder.Services.AddScoped<IRestaurantRepository, RestaurantRepository>();
builder.Services.AddScoped<IYelpRepository, YelpRepository>();

//Context
builder.Services.AddDbContext<Context>(options =>
    options.UseSqlite("Data Source=./database.db"));

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