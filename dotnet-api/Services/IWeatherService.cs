using dotnet_api.Model;

namespace dotnet_api.Services
{
    public interface IWeatherService
    {
        Task<WeatherMapResponse> GetWeather(string lat, string lon);
    }
}