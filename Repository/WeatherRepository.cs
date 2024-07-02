using Newtonsoft.Json.Linq;
using WeatherApp.Data.Mappers;
using WeatherApp.Models;

namespace WeatherApp.Repository
{
    public class WeatherRepository
    {
        private readonly HttpClient _httpClient;
        private readonly WeatherMapper _weatherMapper;
        private readonly string _apiKey = "65753d810c5046e688c192621243006";
        private readonly string _baseUrl = "https://api.weatherapi.com/v1/";

        public WeatherRepository()
        {
            _httpClient = new HttpClient();
            _weatherMapper = new WeatherMapper();
        }

        public async Task<Weather> GetWeatherForecastAsync(string location, int days, string language = "pt")
        {
            try
            {
                var param = "forecast.json";
                var url = $"{_baseUrl}{param}?q={location}&days={days}&lang={language}&key={_apiKey}";
                var response = await _httpClient.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Error fetching weather data");
                }

                var jsonString = await response.Content.ReadAsStringAsync();
                var json = JObject.Parse(jsonString);

                var weather = _weatherMapper.MapWeatherForecast(json);

                return weather;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while fetching weather data: {ex.Message}");
            }
        }
        public async Task<Weather> GetWeatherAsync(string location, string language = "pt")
        {
            try
            {
                var param = "current.json";
                var url = $"{_baseUrl}{param}?q={location}&lang={language}&key={_apiKey}";
                var response = await _httpClient.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Error fetching weather data");
                }

                var jsonString = await response.Content.ReadAsStringAsync();
                var json = JObject.Parse(jsonString);

                var weather = _weatherMapper.MapWeather(json);

                return weather;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while fetching weather data: {ex.Message}");
            }
        }
    }
}
