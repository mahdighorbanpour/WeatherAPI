using MovingDots.MyWeather.Core.OpenWeatherMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MovingDots.MyWeather.Core.Tests
{
    public class WeatherApiSettings_Tests
    {
        [Fact]
        public void WeatherApiSettings_Validate_EmptyOrNullProperties_Should_Throw()
        {
            // arrange
            var settings = new WeatherApiSettings() { ApiAddress = string.Empty, ApiKey = string.Empty };
            // empty string
            Assert.Throws<Exception>(() => settings.Validate());

            settings = new WeatherApiSettings() { ApiAddress = null, ApiKey = null };
            Assert.Throws<Exception>(() => settings.Validate());
        }
    }
}
