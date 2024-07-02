using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using WeatherApp.Models;

public class WeatherService
{
    private readonly HttpClient _httpClient;
    private readonly string _baseUrl;
    private readonly string _apiKey;

    public WeatherService()
    {
        _httpClient = new HttpClient();
        _baseUrl = "http://api.openweathermap.org/data/2.5";
        _apiKey = "ae94ae9ef132dc5d8f5ce9f1e3346b22";
    }

    public async Task<ActionResult<Weather>> GetWeatherForecastAsync(string city)
    {
        try
        {
            var response = await _httpClient.GetStringAsync($"{_baseUrl}/forecast?id=524901&appid={_apiKey}");


            return null;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
}
