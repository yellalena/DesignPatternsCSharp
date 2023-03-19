namespace AdapterPattern
{
    public interface IWeatherService
    {
        public string GetWeather(string cityName);
    }

    public class WeatherService : IWeatherService
    {
        public static Dictionary<string, int> Cities = new();

        public WeatherService() { }
    
        public string GetWeather(string cityName)
        {
            int weather;

            if (Cities.ContainsKey(cityName)) { 
                weather = Cities[cityName];
            }
            else
            {
                Random rnd = new Random();
                weather = rnd.Next(-15, 35);
                Cities.Add(cityName, weather);
            }
            return $"{weather}°C";
        }
    }
}
