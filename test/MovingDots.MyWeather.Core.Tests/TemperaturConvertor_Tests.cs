using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovingDots.MyWeather.Core.OpenWeatherMap;
using Shouldly;
using Xunit;

namespace MovingDots.MyWeather.Core.Tests
{
    [TestClass]
    public class TemperaturConvertor_Tests
    {
        private readonly TemperaturConvertor _convertor;

        public TemperaturConvertor_Tests()
        {
            _convertor = new TemperaturConvertor();
        }

        [Theory]
        [InlineData(0, -273)]
        [InlineData(273, 0)]
        [InlineData(400, 127)]
        [InlineData(200, -73)]
        public void ConvertKelvinTo_Celcius_Should_Work(double temp, double expectedTemp)
        {
            // arrange
            // act
            var tempAfterConvert = _convertor.ConvertKelvinTo(Unit.C, temp);

            // assert
            tempAfterConvert.ShouldBe(expectedTemp);
        }

        [Theory]
        [InlineData(0, -459)]
        [InlineData(273, 32)]
        [InlineData(400, 261)]
        [InlineData(200, -99)]
        public void ConvertKelvinTo_Farenheit_Should_Work(double temp, double expectedTemp)
        {
            // arrange
            // act
            var tempAfterConvert = _convertor.ConvertKelvinTo(Unit.F, temp);

            // assert
            tempAfterConvert.ShouldBe(expectedTemp);
        }
    }
}
