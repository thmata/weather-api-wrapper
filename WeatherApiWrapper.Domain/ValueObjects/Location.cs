namespace WeatherApiWrapper.Domain.ValueObjects;

public class Location
{
    public string City { get; private set; }
    public string Country { get; private set; }

    public Location(string city, string country)
    {
        if (string.IsNullOrEmpty(city)) throw new ArgumentException("City Required");
        if (string.IsNullOrEmpty(country)) throw new ArgumentException("country Required");

        City = city;
        Country = country;
    }

    public override bool Equals(object? obj) =>
       obj is Location other && City == other.City && Country == other.Country;

    public override int GetHashCode() => HashCode.Combine(City, Country);
}
