namespace WeatherApiWrapper.Domain.Exceptions;

public class ApiRateLimitExceededException : DomainException
{
    public TimeSpan RetryAfter { get; }

    public ApiRateLimitExceededException(TimeSpan retryAfter) 
        : base($"API rate limit exceeded. Please try again in {retryAfter.TotalMinutes:F1} minutes")
    {
        RetryAfter = retryAfter;
    }

    public ApiRateLimitExceededException(string message) : base(message)
    {
        RetryAfter = TimeSpan.FromMinutes(1); // Default retry time
    }
}
