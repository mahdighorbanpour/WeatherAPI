using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MovingDots.MyWeather.Core.OpenWeatherMap
{
    public class WeatherService : IWeatherService
    {
        private readonly WeatherApiSettings _settings;
        private readonly HttpClient _httpClient;
        public WeatherService(IOptions<WeatherApiSettings> settings)
        {
            _settings = settings?.Value ?? throw new ArgumentNullException(nameof(settings));
            _settings.Validate();
            _httpClient = new HttpClient();
        }

        public async Task<WeatherInfo> GetWeather(string city, Unit unit)
        {
            // make the request url
            string requestUri = $"{_settings.ApiAddress}?q={city}&appid={_settings.ApiKey}";
            var response = await _httpClient.GetAsync(requestUri);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Something went wrong!");
            }

            string jsonResponse = await response.Content.ReadAsStringAsync();
            var jToken = JsonConvert.DeserializeObject<JObject>(jsonResponse)
                ?.SelectToken("main.temp");

            return jToken is not null
                ? new WeatherInfo() { Temp = jToken.Value<double>() }
                : throw new Exception("Weather info cannot be fetched!");
        }
    }
}
