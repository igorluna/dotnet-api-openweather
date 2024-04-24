using dotnet_api.Model.DTO;

public interface IWeatherIntegrationService{
    Task<OpenWeatherForecastResponseDTO> GetForecast(OpenWeatherForecastRequestDTO request);
}