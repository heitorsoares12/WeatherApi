namespace WeatherApp.Models
{
    public class Weather
    {
        public Location Location { get; set; }
        public Current Current{ get; set; }
        public Forecast Forecast { get; set; }
    }
}
