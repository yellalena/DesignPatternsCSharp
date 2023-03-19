namespace AdapterPattern
{
    public interface IWeatherByZipCodeService
    {
        public string GetWeather(string zipCode);
    }

    public class WeatherByZipCodeService : IWeatherByZipCodeService
    {
        public static readonly WeatherService weatherService = new();
        public static Dictionary<string, string> zipToCityMap;

        public WeatherByZipCodeService() { 
            zipToCityMap = new Dictionary<string, string>{
                { "11080", "Belgrade" },
                { "117463", "Moscow" },
                { "12618", "Tallinn" }
            };
        }

        public string GetWeather(string zipCode)
        {
            if (zipToCityMap.TryGetValue(zipCode, out var cityName))
            {
                return weatherService.GetWeather(cityName);
            }
            throw new Exception("Unknown zip code");
        }
    }
}
