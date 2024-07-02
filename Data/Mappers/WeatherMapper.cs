using Newtonsoft.Json.Linq;
using WeatherApp.Models;

namespace WeatherApp.Data.Mappers
{
    internal class WeatherMapper
    {
        internal Weather MapWeather(JObject json)
        {
            var weather = new Weather
            {
                Location = new Location
                {
                    Name = json["location"]["name"].ToString(),
                    Country = json["location"]["country"].ToString()
                },
                Current = new Current
                {
                    LastUpdated = json["current"]["last_updated"].ToString(),
                    Temp = json["current"]["temp_c"].ToObject<double>(),
                    Condition = new Condition
                    {
                        Text = json["current"]["condition"]["text"].ToString(),
                        Icon = json["current"]["condition"]["icon"].ToString(),
                    },
                    FeelsLike = json["current"]["feelslike_c"].ToObject<double>()
                },
                Forecast = new Forecast
                {
                    ForecastDay = json["forecast"]["forecastday"].Select(forecast => new ForecastDay
                    {
                        Date = forecast["date"].ToString(),
                        Day = new Day
                        {
                            MaxTemp = forecast["day"]["maxtemp_c"].ToObject<double>(),
                            MinTemp = forecast["day"]["mintemp_c"].ToObject<double>(),
                            DailyWillItRain = forecast["day"]["daily_will_it_rain"].ToObject<int>(),
                            DailyChanceOfRain = forecast["day"]["daily_chance_of_rain"].ToObject<int>(),
                            Condition = new Condition
                            {
                                Text = forecast["day"]["condition"]["text"].ToString(),
                                Icon = forecast["day"]["condition"]["icon"].ToString(),
                            }
                        }
                    }).ToList()
                }
            };

            return weather;
        }
    }
}
