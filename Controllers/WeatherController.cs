using Microsoft.AspNetCore.Mvc;
using WeatherApp.Services;
using WeatherApp.Models;

namespace WeatherApp.Controllers
{
    [ApiController]
    [Route("api/weather")]
    public class WeatherController : ControllerBase
    {
        private readonly WeatherService _weatherService;

        public WeatherController()
        {
            _weatherService = new WeatherService();
        }
        [HttpGet("{city}")]
        public async Task<ActionResult<Weather>> GetWeatherForecastAsync(string city)
        {
            try
            {
                var weather = await _weatherService.GetWeatherAsync(city);

                if (weather == null)
                {
                    return NotFound();
                }

                return Ok(weather);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("weather-forecast/{city}")]
        public async Task<ActionResult<Weather>> GetWeatherForecastAsync(string city, int days = 10)
        {
            try
            {
                var weather = await _weatherService.GetWeatherForecastAsync(city, days);

                if (weather == null)
                {
                    return NotFound();
                }

                return Ok(weather);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        
    }
}
