using WeatherApiWrapper.Domain.Entities;

namespace WeatherApiWrapper.Domain.Interfaces;

public interface IWeatherService
{
    Task<WeatherData?> GetWeatherByCityAsync(string city);
    Task<WeatherData?> GetWeatherByCityAsync(string city, string country);
    Task<WeatherData?> GetWeatherByCoordinatesAsync(decimal latitude, decimal longitude);
}