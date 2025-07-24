# Weather API Wrapper Service

A high-performance Weather API Wrapper Service built with ASP.NET Core (.NET 9) following Clean Architecture principles. This service integrates with third-party weather APIs (such as Visual Crossing) and provides weather information through a simple REST API, enhanced with Redis caching for optimal performance.

## 🏗️ Architecture

This project follows **Clean Architecture** principles to ensure:
- **Separation of Concerns**: Each layer has a distinct responsibility
- **Scalability**: Easy to extend and modify
- **Testability**: Loosely coupled components for better unit testing
- **Maintainability**: Clear structure and dependencies

### Project Structure

```
WeatherApiWrapper/
├── WeatherApiWrapper.API/          # Presentation Layer (Controllers, Middleware)
├── WeatherApiWrapper.Application/  # Application Layer (Use Cases, Interfaces)
├── WeatherApiWrapper.Domain/       # Domain Layer (Entities, Value Objects)
└── WeatherApiWrapper.Infrastructure/ # Infrastructure Layer (External APIs, Cache, Data)
```

## ✨ Key Features

- 🌤️ **Real-time Weather Data**: Fetches current weather information from third-party providers
- ⚡ **Redis Caching**: Fast in-memory caching to reduce external API calls and improve response times
- 🏛️ **Clean Architecture**: Promotes maintainability, testability, and scalability
- 🔐 **Secure Configuration**: Uses environment variables for API keys and sensitive data
- 📊 **Simple REST API**: Single endpoint design for easy integration
- ⏰ **Smart Cache Expiration**: Configurable cache TTL (default: 12 hours)
- 🚀 **Production Ready**: Industry-standard patterns and practices

## 🚀 Quick Start

### Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [Redis](https://redis.io/download) (local installation or Redis Cloud)
- Weather API Key (e.g., [Visual Crossing Weather API](https://www.visualcrossing.com/weather-api))

### Installation

1. **Clone the repository**
   ```bash
   git clone https://github.com/thmata/weather-api-wrapper.git
   cd weather-api-wrapper
   ```

2. **Restore dependencies**
   ```bash
   dotnet restore
   ```

3. **Configure environment variables**
   
   Create `appsettings.Development.json` or set environment variables:
   ```json
   {
     "WeatherApi": {
       "ApiKey": "your-weather-api-key",
       "BaseUrl": "https://weather.visualcrossing.com/VisualCrossingWebServices/rest/services/timeline"
     },
     "Redis": {
       "ConnectionString": "localhost:6379"
     },
     "Cache": {
       "ExpirationHours": 12
     }
   }
   ```

4. **Run the application**
   ```bash
   dotnet run --project WeatherApiWrapper.API
   ```

The API will be available at `https://localhost:7000` or `http://localhost:5000`.

## 📋 API Documentation

### Get Weather Information

**Endpoint:** `GET /weather`

**Parameters:**
- `city` (required): The name of the city to get weather information for

**Example Request:**
```bash
curl "https://localhost:7000/weather?city=London"
```

**Example Response:**
```json
{
  "city": "London",
  "country": "United Kingdom",
  "temperature": 18.5,
  "temperatureUnit": "°C",
  "description": "Partly cloudy",
  "humidity": 65,
  "windSpeed": 12.3,
  "windSpeedUnit": "km/h",
  "pressure": 1013.2,
  "pressureUnit": "hPa",
  "lastUpdated": "2025-07-24T10:30:00Z",
  "cached": true
}
```

**Response Codes:**
- `200 OK`: Weather data retrieved successfully
- `400 Bad Request`: Invalid city parameter
- `404 Not Found`: City not found
- `500 Internal Server Error`: Service error

## ⚙️ Configuration

### Environment Variables

| Variable | Description | Default | Required |
|----------|-------------|---------|----------|
| `WeatherApi__ApiKey` | Weather API key | - | Yes |
| `WeatherApi__BaseUrl` | Weather API base URL | - | Yes |
| `Redis__ConnectionString` | Redis connection string | `localhost:6379` | No |
| `Cache__ExpirationHours` | Cache expiration time in hours | `12` | No |

### appsettings.json Structure

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "WeatherApi": {
    "ApiKey": "",
    "BaseUrl": "",
    "TimeoutSeconds": 30
  },
  "Redis": {
    "ConnectionString": "localhost:6379",
    "Database": 0
  },
  "Cache": {
    "ExpirationHours": 12,
    "KeyPrefix": "weather:"
  }
}
```

## 🧪 Testing

Run unit tests:
```bash
dotnet test
```

Run with coverage:
```bash
dotnet test --collect:"XPlat Code Coverage"
```

## 🏗️ Development

### Building the Solution

```bash
# Build entire solution
dotnet build

# Build specific project
dotnet build WeatherApiWrapper.API
```

### Running in Development Mode

```bash
dotnet run --project WeatherApiWrapper.API --environment Development
```

### Docker Support

```bash
# Build Docker image
docker build -t weather-api-wrapper .

# Run with Docker Compose (includes Redis)
docker-compose up -d
```

## 📊 Performance Considerations

- **Caching Strategy**: Weather data is cached using Redis with configurable TTL
- **Rate Limiting**: Consider implementing rate limiting for production use
- **Connection Pooling**: HTTP client factory pattern for efficient API calls
- **Async/Await**: Fully asynchronous implementation for better scalability

## 🛡️ Security

- **API Key Protection**: Never commit API keys to version control
- **HTTPS**: Always use HTTPS in production
- **Input Validation**: All inputs are validated and sanitized
- **Error Handling**: Graceful error handling without exposing sensitive information

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add some amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

## 📝 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## � Implementation Tasks

Below is the ordered task list to implement this Weather API Wrapper project from scratch:

### Phase 1: Foundation Setup
- [ ] **1.1** Set up project structure and dependencies
  - Configure solution file and project references
  - Add required NuGet packages (Redis, HTTP Client, Configuration, etc.)
  - Set up project dependencies between layers

### Phase 2: Domain Layer Implementation
- [ ] **2.1** Create Domain Entities
  - `WeatherData` entity with properties (Temperature, Humidity, etc.)
  - `Location` value object for city/country information
  - `WeatherCondition` value object for weather descriptions

- [ ] **2.2** Define Domain Interfaces
  - `IWeatherService` interface for weather operations
  - `ICacheService` interface for caching operations
  - Common result patterns and exceptions

### Phase 3: Application Layer Implementation
- [ ] **3.1** Create DTOs and Models
  - `WeatherRequestDto` for API requests
  - `WeatherResponseDto` for API responses
  - Mapping profiles (AutoMapper or manual mapping)

- [ ] **3.2** Implement Use Cases
  - `GetWeatherByCity` use case with business logic
  - Input validation and error handling
  - Cache-first strategy implementation

- [ ] **3.3** Define Application Interfaces
  - `IWeatherApiClient` for external API integration
  - `ICacheRepository` for cache operations
  - Configuration option classes

### Phase 4: Infrastructure Layer Implementation
- [ ] **4.1** External API Integration
  - Implement `WeatherApiClient` for Visual Crossing API
  - HTTP client configuration with retry policies
  - API response mapping and error handling

- [ ] **4.2** Redis Cache Implementation
  - Implement `RedisCacheService` 
  - Cache key generation strategy
  - Serialization/deserialization logic
  - Cache expiration and invalidation

- [ ] **4.3** Configuration Setup
  - Weather API configuration class
  - Redis configuration class
  - Dependency injection container setup

### Phase 5: API Layer Implementation
- [ ] **5.1** Create Weather Controller
  - `GET /weather` endpoint implementation
  - Parameter validation and binding
  - Response formatting and status codes

- [ ] **5.2** Middleware and Error Handling
  - Global exception handling middleware
  - Request/response logging
  - API versioning setup (if needed)

- [ ] **5.3** API Configuration
  - Swagger/OpenAPI documentation
  - CORS configuration
  - Health checks implementation

### Phase 6: Configuration and Security
- [ ] **6.1** Environment Configuration
  - `appsettings.json` structure
  - Environment-specific settings
  - Secrets management (User Secrets, Environment Variables)

- [ ] **6.2** Security Implementation
  - Input validation and sanitization
  - Rate limiting (optional)
  - HTTPS configuration

### Phase 7: Testing Implementation
- [ ] **7.1** Unit Tests
  - Domain layer unit tests
  - Application layer unit tests
  - Infrastructure layer unit tests (with mocks)

- [ ] **7.2** Integration Tests
  - API controller integration tests
  - Redis cache integration tests
  - External API integration tests (with test doubles)

- [ ] **7.3** End-to-End Tests
  - Complete workflow testing
  - Cache behavior validation
  - Error scenario testing

### Phase 8: DevOps and Deployment
- [ ] **8.1** Containerization
  - Create Dockerfile for the application
  - Docker Compose setup with Redis
  - Environment variable configuration

- [ ] **8.2** Documentation and Scripts
  - Update README with final instructions
  - Create deployment scripts
  - Add development setup guide

### Phase 9: Performance and Monitoring
- [ ] **9.1** Performance Optimization
  - HTTP client pooling optimization
  - Cache strategy fine-tuning
  - Async/await best practices review

- [ ] **9.2** Monitoring Setup
  - Application logging configuration
  - Health check endpoints
  - Metrics collection (optional)

### Phase 10: Final Polish
- [ ] **10.1** Code Review and Cleanup
  - Code style and formatting consistency
  - Remove unused dependencies
  - Documentation review

- [ ] **10.2** Production Readiness
  - Security audit
  - Performance testing
  - Deployment validation

## 🎯 Priority Order

**High Priority (MVP):**
- Phases 1-6: Core functionality implementation
- Basic testing (Phase 7.1-7.2)

**Medium Priority:**
- Complete testing suite (Phase 7.3)
- Containerization (Phase 8.1)

**Low Priority (Nice to have):**
- Advanced monitoring (Phase 9.2)
- Performance optimization (Phase 9.1)

## 📝 Task Tracking

You can track your progress by checking off completed tasks. Each phase builds upon the previous one, so it's recommended to complete them in order.

## �🔗 Links

- [Visual Crossing Weather API Documentation](https://www.visualcrossing.com/resources/documentation/weather-api/)
- [Redis Documentation](https://redis.io/documentation)
- [ASP.NET Core Documentation](https://docs.microsoft.com/en-us/aspnet/core/)
- [Clean Architecture Guide](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html)

---

**Built with ❤️ using ASP.NET Core and Clean Architecture principles**