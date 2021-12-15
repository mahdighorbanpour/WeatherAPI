namespace MovingDots.MyWeather.Core.OpenWeatherMap
{
    public interface IWeatherService
    {
        Task<WeatherInfo> GetWeather(string city, Unit unit);
    }
}
