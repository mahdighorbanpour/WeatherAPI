using Microsoft.AspNetCore.Mvc;

namespace MovingDots.MyWeather.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherService _weatherService;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(
            IWeatherService weatherService,
            ILogger<WeatherForecastController> logger)
        {
            _weatherService = weatherService;
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public Task<WeatherInfo> Get(string city)
        {
            return _weatherService.GetWeather(city, Unit.C);
        }
    }
}
