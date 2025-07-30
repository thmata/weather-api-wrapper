namespace WeatherApiWrapper.Domain.Exceptions;

public class CityNotFoundException : DomainException
{
    public string City { get; }
    public string? Country { get; }

    public CityNotFoundException(string city) 
        : base($"City '{city}' was not found")
    {
        City = city;
    }

    public CityNotFoundException(string city, string country) 
        : base($"City '{city}' in country '{country}' was not found")
    {
        City = city;
        Country = country;
    }
}
