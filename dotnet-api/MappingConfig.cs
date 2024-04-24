using AutoMapper;
using dotnet_api.Model;
using dotnet_api.Model.DTO;


namespace dotnet_api
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            // Integration Mapping
            CreateMap<Model.DTO.OpenWeatherForecastResponseDTO, Model.WeatherMapResponse>().ReverseMap();
            CreateMap<Model.DTO.List, Model.WeatherData>().ReverseMap();
            CreateMap<Model.DTO.Main, Model.Main>().ReverseMap();
            CreateMap<Model.DTO.City, Model.City>().ReverseMap();
            CreateMap<Model.DTO.Coord, Model.Coord>().ReverseMap();
            CreateMap<Model.DTO.Weather, Model.Weather>().ReverseMap();
        }
    }
}