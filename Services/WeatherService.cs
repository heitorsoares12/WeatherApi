using WeatherApp.Models;
using WeatherApp.Repository;

namespace WeatherApp.Services
{
    public class WeatherService
    {
        private readonly WeatherRepository _weatherRepository;

        public WeatherService()
        {
            _weatherRepository = new WeatherRepository();
        }

        public async Task<Weather> GetWeatherForecastAsync(string location, int days)
        {
            return await _weatherRepository.GetWeatherForecastAsync(location, days);
        }

        public async Task<Weather> GetWeatherAsync(string location)
        {
            return await _weatherRepository.GetWeatherAsync(location);
        }
    }
}
