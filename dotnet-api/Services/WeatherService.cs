using AutoMapper;
using dotnet_api.Model;
using dotnet_api.Model.DTO;
using Newtonsoft.Json;

namespace dotnet_api.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly IWeatherIntegrationService _weatherIntegrationService;
        private readonly IMapper _mapper;
        private readonly ILogRequestService _logService;

        public WeatherService(
            IMapper mapper,
            IWeatherIntegrationService weatherIntegrationService,
            ILogRequestService logService)
        {
            _mapper = mapper;
            _weatherIntegrationService = weatherIntegrationService;
            _logService = logService;
        }

        public async Task<WeatherMapResponse> GetWeather(string lat, string lon)
        {
            var response = await this._weatherIntegrationService.GetForecast(new OpenWeatherForecastRequestDTO{ lat=lat, lon = lon });
            
            string jsonRequest = $"{{ \"lat\":\"{lat}\", \"lon\":\"{lon}\"  }}";
            string jsonResponse = JsonConvert.SerializeObject(response);
            _logService.LogRequest(new RequestLog{ JsonRequest = jsonRequest, JsonResponse = jsonResponse});

            WeatherMapResponse mapped = _mapper.Map<WeatherMapResponse>(response);

            return mapped;
        }
    }
}