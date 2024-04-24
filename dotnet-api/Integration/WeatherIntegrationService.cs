using dotnet_api.Model.DTO;
using Newtonsoft.Json;

public class WeatherIntegrationService : IWeatherIntegrationService
{
    static HttpClient client = new HttpClient();
    string apiKey;
    string urlPath;

    public WeatherIntegrationService(OpenweatherConfig openweatherConfig)
    {
        apiKey = openweatherConfig.ApiKey;
        urlPath = openweatherConfig.Url;
    }

    public async Task<OpenWeatherForecastResponseDTO> GetForecast(OpenWeatherForecastRequestDTO request)
    {
        OpenWeatherForecastResponseDTO? weatherMapResponse = new OpenWeatherForecastResponseDTO();

        string path  = $"{urlPath}/forecast?lat={request.lat}&lon={request.lon}&appid={apiKey}";
        
        HttpResponseMessage response = await client.GetAsync(path);
        if (response.IsSuccessStatusCode)
        {
            var jsonResponse = await response.Content.ReadAsStringAsync();
            weatherMapResponse = JsonConvert.DeserializeObject<OpenWeatherForecastResponseDTO>(jsonResponse);
        }

        return weatherMapResponse;
    }
}