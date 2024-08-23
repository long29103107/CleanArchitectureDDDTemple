using Microsoft.AspNetCore.Mvc;
using Product.Presentation;
using Infrastructures.DependencyInjection.Extensions;
using Product.Persistence.Repositories;
using Product.Persistence.Repositories.Abstractions;
using Product.Application.DependencyInjection.Extensions;
using Product.Persistence.DependencyInjection.Extensions;
using Package.Shared.ExceptionHandler;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

builder.Services.AddControllers(config =>
{
    config.RespectBrowserAcceptHeader = true;
    config.ReturnHttpNotAcceptable = true;
    config.Filters.Add(new ProducesAttribute("application/json", "text/plain", "text/json"));
}).AddApplicationPart(ProductPresentationReference.Assembly);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();
builder.Host.UseSerilog((context, loggerConfiguration) =>
{
    loggerConfiguration.WriteTo.Console();
    loggerConfiguration.ReadFrom.Configuration(context.Configuration);
});

//Add service building block
builder.Services.AddServiceInfrastructuresBuildingBlock();

//Add DI Application
builder.Services.AddServiceApplication();
builder.Services.AddServicePersistence(builder.Configuration);

builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

var app = builder.Build();

app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
