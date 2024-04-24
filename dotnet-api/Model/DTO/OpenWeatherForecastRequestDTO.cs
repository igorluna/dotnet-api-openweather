using System.ComponentModel.DataAnnotations;

namespace dotnet_api.Model.DTO{
    public class OpenWeatherForecastRequestDTO
    {
        [Required]
        public string lat;

        [Required]
        public string lon;

        public string mode;

        public string units;

        public string lang;
    }
}