namespace MovingDots.MyWeather.Core.OpenWeatherMap
{
    public interface ITemperaturConvertor
    {
        double ConvertKelvinTo(Unit unit, double temp);
    }
}