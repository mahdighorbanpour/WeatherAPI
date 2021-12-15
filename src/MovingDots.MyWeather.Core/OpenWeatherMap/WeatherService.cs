using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovingDots.MyWeather.Core.OpenWeatherMap
{
    public class WeatherService : IWeatherService
    {
        private readonly WeatherApiSettings _settings;

        public WeatherService(IOptions<WeatherApiSettings> settings)
        {
            _settings = settings?.Value ?? throw new ArgumentNullException(nameof(settings));
            _settings.Validate();
        }
    }
}
