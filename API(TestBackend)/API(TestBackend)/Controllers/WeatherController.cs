using API_TestBackend_.Models;
using API_TestBackend_.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_TestBackend_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly ILogger<WeatherController> _logger;
        private readonly IWeatherService _weatherService;

        public WeatherController(ILogger<WeatherController> logger, IWeatherService weatherService)
        {
            _logger = logger;
            _weatherService = weatherService;
        }

        [HttpGet("{cityName}")]
        public async Task<ActionResult<WeatherData>> GetWeather(string cityName)
        {
            if (string.IsNullOrEmpty(cityName))
            {
                return BadRequest("City name is required.");
            }
            var weatherResponce = await _weatherService.GetWeatherDataAsync(cityName);

            if (weatherResponce.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return Ok(weatherResponce);
            }
            else if (weatherResponce.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return NotFound(weatherResponce);
            }
            else
            {
                return StatusCode((int)weatherResponce.StatusCode, weatherResponce);
            }
        }
    }
}
