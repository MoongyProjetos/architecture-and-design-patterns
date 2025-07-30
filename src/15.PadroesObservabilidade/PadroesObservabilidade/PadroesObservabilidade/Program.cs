using Azure.Identity;
using System.Diagnostics;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.Configure<Microsoft.ApplicationInsights.Extensibility.TelemetryConfiguration>(config =>
{
config.SetAzureTokenCredential(new DefaultAzureCredential());
});

builder.Services.AddApplicationInsightsTelemetry(new Microsoft.ApplicationInsights.AspNetCore.Extensions.ApplicationInsightsServiceOptions
{
    ConnectionString = builder.Configuration["APPLICATIONINSIGHTS_CONNECTION_STRING"]
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();

    var random = new Random().Next(99);

    //Exemplo para forçar vários erros
    if(random % 7 == 0 || random % 3 == 0)
    {
        app.Logger.LogError("Erro divisão");
        app.Logger.LogTrace(new Exception("Erro divisão"), "erro", null);
    }

    return forecast;
})
.WithName("GetWeatherForecast");


app.MapGet("/warning", () =>
{
    app.Logger.LogWarning("Mensagem de alerta!");

    using var client = new HttpClient();
    var response = client.GetAsync("https://www.bing.com/").Result;

    return $"Hello World! OpenTelemetry Trace: {Activity.Current?.Id}";
});

app.MapGet("/", () =>
{
    app.Logger.LogInformation("Hello World!");

    using var client = new HttpClient();
    var response = client.GetAsync("https://www.bing.com/").Result;

    return $"Hello World! OpenTelemetry Trace: {Activity.Current?.Id}";
});



app.MapGet("/fazTudo", () =>
{
    var clientWarning = new HttpClient();
    var request = new HttpRequestMessage(HttpMethod.Get, "/warning");
    var responseWarning = clientWarning.SendAsync(request);

    var requestLocal = new HttpRequestMessage(HttpMethod.Get, "/");
    var responseLocal = clientWarning.SendAsync(requestLocal);

    //



    return $"Operacoes efetuadas com sucesso";
});

app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
