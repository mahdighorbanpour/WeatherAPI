using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MovingDots.MyWeather.Core.OpenWeatherMap
{
    public class WeatherService : IWeatherService
    {
        private readonly WeatherApiSettings _settings;
        private readonly HttpClient _httpClient;
        private readonly ITemperaturConvertor _temperaturConvertor;

        public WeatherService(
            IOptions<WeatherApiSettings> settings,
            ITemperaturConvertor temperaturConvertor)
        {
            _settings = settings?.Value ?? throw new ArgumentNullException(nameof(settings));
            _settings.Validate();
            _httpClient = new HttpClient();
            _temperaturConvertor = temperaturConvertor;
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

            var tempNotConverted = jToken is not null
                ? jToken.Value<double>()
                : throw new Exception("Weather info cannot be fetched!");

            var tempreaturConverted = _temperaturConvertor.ConvertKelvinTo(unit, tempNotConverted);
            return new WeatherInfo() { Temp = tempreaturConverted };
        }
    }
}
