namespace WeatherApiWrapper.Domain.Exceptions;

public class InvalidCoordinatesException : DomainException
{
    public decimal Latitude { get; }
    public decimal Longitude { get; }

    public InvalidCoordinatesException(decimal latitude, decimal longitude) 
        : base($"Invalid coordinates: Latitude {latitude}, Longitude {longitude}")
    {
        Latitude = latitude;
        Longitude = longitude;
    }
}
