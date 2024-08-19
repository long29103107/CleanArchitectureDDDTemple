using Microsoft.AspNetCore.Mvc;
using Product.Presentation;
using Microsoft.EntityFrameworkCore; 
using Infrastructures.DependencyInjection.Extensions;
using Product.Application;
using System.Reflection;
using Product.Persistence.Abstractions;
using Product.Persistence.Implement;
using Product.Persistence;
using Product.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

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

//Add service building block
builder.Services.AddServiceInfrastructuresBuildingBlock();

//Add DI Application
//builder.Services.AddMediatRApplication();
builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddDbContext<ProductDbContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("Product")
        , b => b.MigrationsAssembly(ProductPersistenceReference.AssemblyName));
});

builder.Services.AddMediatR(cfg =>
        cfg.RegisterServicesFromAssemblies(new Assembly[]
        {
            ProductApplicationReference.Assembly,
            ProductPresentationReference.Assembly
        }));

var app = builder.Build();

// Configure the HTTP request pipeline.
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
