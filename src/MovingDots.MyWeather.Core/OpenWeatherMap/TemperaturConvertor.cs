namespace MovingDots.MyWeather.Core.OpenWeatherMap
{
    public class TemperaturConvertor : ITemperaturConvertor
    {
        public double ConvertKelvinTo(Unit unit, double temp)
        {
            return unit switch
            {
                Unit.F => ConvertToFarenheit(temp),
                Unit.C => ConvertToCelcius(temp),
                _ => throw new NotImplementedException()
            };
        }

        private double ConvertToCelcius(double temp)
        {
            // convertion of K to C = K - 273
            return (temp - 273);
        }

        private double ConvertToFarenheit(double temp)
        {
            // convertion of K to F = 1.8 x (K - 273) + 32 
            return Math.Ceiling(1.8 * (temp - 273) + 32);
        }
    }
}
