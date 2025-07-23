using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Seguradora.Data;
using Seguradora.Data.CacheService;
using Seguradora.Data.CQRS;
using Seguradora.Data.QueueService;
using MediatR; // Ensure this namespace is included  

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.  

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi  
builder.Services.AddOpenApi();

builder.Services.AddDbContext<SeguradoraDbContext>(opt => opt.UseInMemoryDatabase("Seguradora"));
builder.Services.AddMemoryCache();
builder.Services.AddScoped<ISinistroCacheService, SinistroCacheService>();
builder.Services.AddScoped<IQueueService, QueueServiceSimulado>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<CriarSinistroCommand>()); // Updated line  

var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.  
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
