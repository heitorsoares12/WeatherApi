namespace WeatherApp.Models
{
    public class Day
    {
        public double MaxTemp { get; set; }
        public double MinTemp { get; set; }
        public int DailyWillItRain { get; set; }
        public int DailyChanceOfRain { get; set; }
        public Condition Condition { get; set; }
    }
}
