namespace WeatherApiWrapper.Domain.Exceptions;

public class WeatherServiceException : DomainException
{
    public WeatherServiceException(string message) : base(message)
    {
    }

    public WeatherServiceException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
