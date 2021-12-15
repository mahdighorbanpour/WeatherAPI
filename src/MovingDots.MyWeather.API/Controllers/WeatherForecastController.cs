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

        [HttpGet("{city}/{unit}", Name = "GetWeatherForecast")]
        public Task<WeatherInfo> Get([FromRoute] string city, [FromRoute] Unit unit = Unit.C)
        {
            return _weatherService.GetWeather(city, unit);
        }
    }
}
