using FilmesAPI.Data;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

//CRIANDO CONEXAO COM O BANCO DE DADOS ATRAVES DO BUILDER
var connectionString = builder.Configuration.GetConnectionString("FilmeConnection");



builder.Services.AddDbContext<FilmesContext>(opts =>
    opts.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services
    .AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
//END



// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
