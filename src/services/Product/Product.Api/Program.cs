using Microsoft.AspNetCore.Mvc;
using Product.Presentation;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
    //(config =>
    //{
    //    config.RespectBrowserAcceptHeader = true;
    //    config.ReturnHttpNotAcceptable = true;
    //    config.Filters.Add(new ProducesAttribute("application/json", "text/plain", "text/json"));
    //}).AddApplicationPart(typeof(PresentationReference).Assembly);

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

app.UseRouting();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
