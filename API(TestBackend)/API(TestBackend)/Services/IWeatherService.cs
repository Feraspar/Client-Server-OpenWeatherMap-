using API_TestBackend_.Models;

namespace API_TestBackend_.Services
{
    public interface IWeatherService
    {
        Task<WeatherResponse> GetWeatherDataAsync(string cityName);
    }
}
