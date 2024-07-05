namespace WeatherApp.Models
{
    public class Current
    {
        public string LastUpdated { get; set; }
        public double Temp {  get; set; }
        public double FeelsLike { get; set; }
        public Condition Condition { get; set; }

    }
}
