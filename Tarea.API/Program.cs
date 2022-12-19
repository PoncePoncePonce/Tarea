using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Tarea.API.Extenciones;
using Tarea.Infraestructura.SQL.SQL_Server.Repositorios;
using Tarea.Business.Interfaces;
using Tarea.Infraestructura.SQLServer.SQL_Server.Repositorios;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.
//var connection = builder.Configuration.GetConnectionString("SQLConnectionStr");
//builder.Services.ConfigureSQLDbContext(connection);

////Inyectar Dependencia
//builder.Services.AddScoped<ICitaRepository, CitaSQLRepository>();
//builder.Services.AddScoped<IClientesRepository, ClientesSQLRepository>();
//builder.Services.AddScoped<IDoctoresRepository, DoctorSQLRepository>();

//builder.Services.AddScoped < ILogger, Tarea.Transversal.Loggers.Logger<ControllerBase>();

//ICitaRepository repo = new CitaSQLRepository();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(x=>
    {
        x.SwaggerEndpoint("/Swagger/v1/Swagger.json", "Tarea.API");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();