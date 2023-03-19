using AdapterPattern;

class Adapter
{
    public static void Main()
    {
        WeatherService weatherService = new();
        WeatherByZipCodeService weatherByZipCodeService = new();

        Console.WriteLine($"Tallinn weather by cityname: {weatherService.GetWeather("Tallinn")}, " +
                        $"by zipcode: {weatherByZipCodeService.GetWeather("12618")}.");

        Console.WriteLine($"Moscow weather by cityname: {weatherService.GetWeather("Moscow")}, " +
                $"by zipcode: {weatherByZipCodeService.GetWeather("117463")}.");

        Console.WriteLine($"Belgrade weather by cityname: {weatherService.GetWeather("Belgrade")}, " +
        $"by zipcode: {weatherByZipCodeService.GetWeather("11080")}.");
    }
}