using dotnet_api;
using dotnet_api.Model;
using dotnet_api.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true);

var openweatherConfig = builder.Configuration.GetSection("OpenweatherApiConfiguration").Get<OpenweatherConfig>();
builder.Services.AddSingleton(openweatherConfig);

var connectionString = builder.Configuration.GetConnectionString("LogMSSql");
builder.Services.AddDbContext<LogDbContext>(options=> options.UseSqlServer(connectionString));

builder.Services.AddScoped<ILogRequestService, LogRequestService>();
builder.Services.AddScoped<IWeatherService, WeatherService>();
builder.Services.AddScoped<IWeatherIntegrationService, WeatherIntegrationService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MappingConfig));

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "MyAllowSpecificOrigins",
                      policy  =>
                      {
                          policy.WithOrigins("http://localhost:4200");
                      });
                      
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("MyAllowSpecificOrigins");

app.MapGet("/api/forecast", async (
    IMapper _mapper,
    IWeatherService _weatherService,
    [FromQuery] string lat,
    [FromQuery] string lon) => 
{
    APIResponse response;
    WeatherMapResponse result = new WeatherMapResponse();
    try{
        result = await _weatherService.GetWeather(lat, lon);

        if(result == null)
        {
            response = new APIResponse
            {
                IsSuccess = false,
                StatusCode = System.Net.HttpStatusCode.NotFound
            };
            return Results.NotFound(response);
        }
    }
    catch(Exception ex){
        
        response = new APIResponse
        {
            Result = result,
            IsSuccess = true,
            StatusCode = System.Net.HttpStatusCode.InternalServerError
        };
        return Results.BadRequest(response);
    }

    response = new APIResponse
    {
        Result = result,
        IsSuccess = true,
        StatusCode = System.Net.HttpStatusCode.OK
    };

    return Results.Ok(response);
});

app.Run();
