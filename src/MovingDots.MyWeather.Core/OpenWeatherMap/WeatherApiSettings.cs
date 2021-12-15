namespace MovingDots.MyWeather.Core.OpenWeatherMap
{
    public class WeatherApiSettings
    {
        public string? ApiAddress { get; set; }
        public string? ApiKey { get; set; }

        public void Validate()
        {
            if (string.IsNullOrEmpty(ApiAddress) || string.IsNullOrWhiteSpace(ApiKey))
            {
                throw new Exception("API settings is invalid!");
            }
        }
    }
}
