
namespace dotnet_api.Model
{
    public class WeatherMapResponse
    {
        public int message { get; set; }
        public int cnt { get; set; }
        public List<WeatherData> list { get; set; }
        public City city { get; set; }
    }

    public class City
    {
        public string name { get; set; }
        public Coord coord { get; set; }
        public string country { get; set; }
        public int timezone { get; set; }
        public int sunrise { get; set; }
        public int sunset { get; set; }
    }
    public class Coord
    {
        public double lat { get; set; }
        public double lon { get; set; }
    }

    public class WeatherData{
        
        public int dt { get; set; }
        public Main main { get; set; }
        public List<Weather> weather { get; set; }
        public string dt_txt { get; set; }
    }
    public class Weather
    {
        // public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }
    public class Main
    {
        public double temp { get; set; }
        public double feels_like { get; set; }
        public double temp_min { get; set; }
        public double temp_max { get; set; }
        public int pressure { get; set; }
        public int sea_level { get; set; }
        public int grnd_level { get; set; }
        public int humidity { get; set; }
        public double temp_kf { get; set; }
    }
}