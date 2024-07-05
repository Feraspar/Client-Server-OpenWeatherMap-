using API_TestBackend_.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Net;

namespace API_TestBackend_.Services
{
    public class OpenWeatherMapService: IWeatherService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public OpenWeatherMapService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiKey = configuration["OpenWeatherMapApiKey"];
        }

        public async Task<WeatherResponse> GetWeatherDataAsync(string cityName)
        {
            try
            {
                string apiUrl = $"https://api.openweathermap.org/data/2.5/weather?q={cityName}&appid={_apiKey}&units=metric";

                HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);
                if (!response.IsSuccessStatusCode)
                {
                    return new WeatherResponse
                    {
                        StatusCode = response.StatusCode,
                        Message = $"Failed to get weather data. Status code: {response.StatusCode}"
                    };
                }

                var result = await response.Content.ReadFromJsonAsync<OpenWeatherMapResponce>();
                if (result == null)
                {
                    return new WeatherResponse
                    {
                        StatusCode = response.StatusCode,
                        Message = "Failed to parse weather data."
                    };
                }

                var weatherData = new WeatherData
                {
                    City = result.Name,
                    CityTime = DateTime.UtcNow.AddSeconds(result.Timezone),
                    ServerTime = DateTime.UtcNow,
                    TimeDifference = TimeSpan.FromSeconds(result.Timezone),
                    TemperatureC = result.Main?.Temp,
                    Pressure = result.Main?.Pressure,
                    Humidity = result.Main?.Humidity,
                    WindSpeed = result.Wind?.Speed,
                    Cloudy = result.Clouds?.All
                };

                return new WeatherResponse
                {
                    StatusCode = response.StatusCode,
                    Message = "Success",
                    WeatherData = weatherData
                };
            }

            catch (Exception ex)
            {
                return new WeatherResponse
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Message = $"Exception: {ex.Message}"
                };
            }
        }
    }

    public class OpenWeatherMapResponce
    {
        public string Name { get; set; }
        public long Timezone { get; set; }

        public MainInfo Main { get; set; }

        public WindInfo Wind { get; set; }

        public CloudsInfo Clouds { get; set; }
    }

    public class MainInfo
    {
        public double Temp { get; set; }
        public double Pressure { get; set; }
        public int Humidity { get; set; }
    }

    public class WindInfo
    {
        public double Speed { get; set; }
    }

    public class CloudsInfo
    {
        public int All { get; set; }
    }

    public class WeatherResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }
        public WeatherData WeatherData { get; set; }
    }
}
