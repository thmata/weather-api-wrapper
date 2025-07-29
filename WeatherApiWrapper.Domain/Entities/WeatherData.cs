using WeatherApiWrapper.Domain.Enums;
using WeatherApiWrapper.Domain.ValueObjects;

namespace WeatherApiWrapper.Domain.Entities;

public class WeatherData
{
    public Guid Id { get; private set; }
    public decimal Temperature { get; private set; }
    public TemperatureUnit TemperatureUnit { get; private set; }
    public int Humidity { get; private set; } 
    public decimal Pressure { get; private set; }
    public PressureUnit PressureUnit { get; private set; }
    public decimal WindSpeed { get; private set; }
    public SpeedUnit WindSpeedUnit { get; private set; }
    public Location Location { get; private set; }
    public string Condition { get; private set; }
    public DateTime LastUpdated { get; private set; }

    public WeatherData(
        decimal temperature,
        TemperatureUnit temperatureUnit,
        int humidity,
        decimal pressure,
        PressureUnit pressureUnit,
        decimal windSpeed,
        SpeedUnit windSpeedUnit,
        Location location,
        string condition)
    {
        // Validation
        ValidateTemperature(temperature);
        ValidateHumidity(humidity);
        ValidatePressure(pressure);
        ValidateWindSpeed(windSpeed);
        ValidateCondition(condition);

        Id = Guid.NewGuid();
        Temperature = temperature;
        TemperatureUnit = temperatureUnit;
        Humidity = humidity;
        Pressure = pressure;
        PressureUnit = pressureUnit;
        WindSpeed = windSpeed;
        WindSpeedUnit = windSpeedUnit;
        Location = location ?? throw new ArgumentNullException(nameof(location));
        Condition = condition;
        LastUpdated = DateTime.UtcNow;
    }

    public void UpdateTemperature(decimal newTemp, TemperatureUnit temperatureUnit)
    {
        ValidateTemperature(newTemp);
        
        Temperature = newTemp;
        TemperatureUnit = temperatureUnit;
        LastUpdated = DateTime.UtcNow;
    }

    public void UpdateCondition(string newCondition)
    {
        ValidateCondition(newCondition);
        Condition = newCondition;
        LastUpdated = DateTime.UtcNow;
    }

    public void UpdateHumidity(int newHumidity)
    {
        ValidateHumidity(newHumidity);
        Humidity = newHumidity;
        LastUpdated = DateTime.UtcNow;
    }

    public void UpdatePressure(decimal newPressure, PressureUnit pressureUnit)
    {
        ValidatePressure(newPressure);
        Pressure = newPressure;
        PressureUnit = pressureUnit;
        LastUpdated = DateTime.UtcNow;
    }

    public void UpdateWindSpeed(decimal newWindSpeed, SpeedUnit speedUnit)
    {
        ValidateWindSpeed(newWindSpeed);
        WindSpeed = newWindSpeed;
        WindSpeedUnit = speedUnit;
        LastUpdated = DateTime.UtcNow;
    }

    private static void ValidateTemperature(decimal temperature)
    {
        if (temperature < -100 || temperature > 70)
            throw new ArgumentException("Temperature must be between -100°C and 70°C", nameof(temperature));
    }

    private static void ValidateHumidity(int humidity)
    {
        if (humidity < 0 || humidity > 100)
            throw new ArgumentException("Humidity must be between 0% and 100%", nameof(humidity));
    }

    private static void ValidatePressure(decimal pressure)
    {
        if (pressure <= 0 || pressure > 2000)
            throw new ArgumentException("Pressure must be between 0 and 2000 hPa", nameof(pressure));
    }

    private static void ValidateWindSpeed(decimal windSpeed)
    {
        if (windSpeed < 0 || windSpeed > 500)
            throw new ArgumentException("Wind speed must be between 0 and 500 km/h", nameof(windSpeed));
    }

    private static void ValidateCondition(string condition)
    {
        if (string.IsNullOrWhiteSpace(condition))
            throw new ArgumentException("Condition cannot be null or empty", nameof(condition));
        
        if (condition.Length > 100)
            throw new ArgumentException("Condition description cannot exceed 100 characters", nameof(condition));
    }
}