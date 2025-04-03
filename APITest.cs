using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DatabaseApp
{
    class APITest
    {
        private HttpClient client = new HttpClient();
        private string APIKey = "6fb6393de1c1d62c1ee56bfa378a625c";

        public async Task GetWeatherByCity(string city)
        {
            // Znajdujemy współrzędne miasta 
            string geoUrl = $"http://api.openweathermap.org/geo/1.0/direct?q={city}&limit=1&appid={APIKey}";
            string geoResponse = await client.GetStringAsync(geoUrl);
            Location[] locations = JsonSerializer.Deserialize<Location[]>(geoResponse);

            // Console.WriteLine(geoResponse);     // Odpowiedź z API
            // Console.WriteLine("\n");

            if (locations == null || locations.Length == 0)
            {
                Console.WriteLine("Nie znaleziono miasta.");
                return;
            }

            double lat = locations[0].lat;
            double lon = locations[0].lon;

            // Pobieramy dane pogodowe na podstawie współrzędnych
            string weatherUrl = $"https://api.openweathermap.org/data/2.5/weather?lat={lat}&lon={lon}&appid={APIKey}";
            string weatherResponse = await client.GetStringAsync(weatherUrl);

            // Console.WriteLine(weatherResponse);     // Odpowiedź z API

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            WeatherData weatherData = JsonSerializer.Deserialize<WeatherData>(weatherResponse, options);

            if (weatherData == null)
            {
                Console.WriteLine("Błąd: Nie udało się pobrać danych pogodowych.");
                return;
            }

            weatherData.Main.Temp -= 273.15;   // Konwersja temperatury z Kelvina na Celsjusza
            Console.WriteLine(weatherData);
        }
    }
}
