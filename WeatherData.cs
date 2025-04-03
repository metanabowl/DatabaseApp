using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseApp
{
    class WeatherData
    {
        public SysData Sys { get; set; }        // Dane o wschodzie i zachodzie słońca
        public MainData Main { get; set; }      // Dane o temperaturze i wilgotności
        public WindData Wind { get; set; }      // Dane o wietrze (prędkość i kierunek)
        public CloudData Clouds { get; set; }   // Dane o zachmurzeniu (%)
        public RainData Rain { get; set; }      // Dane o opadach (jeśli są)
        public WeatherDescription[] Weather { get; set; }   // Opis pogody

        public override string ToString()
        {
            return $"Temperature: {Main.Temp}°C\n" +
                   $"Humidity: {Main.Humidity}%\n" +
                   $"Wind: {Wind?.Speed} m/s, {Wind?.Deg}°\n" +
                   $"Clouds: {Clouds?.All}%\n" +
                   $"{(Rain != null ? $"Rain: {Rain.OneHour} mm/h\n" : "")}" +
                   $"Sunrise: {UnixToDateTime(Sys?.Sunrise)}\n" +
                   $"Sunset: {UnixToDateTime(Sys?.Sunset)}\n" +
                   $"Description: {Weather[0].Description}";
        }

        private static string UnixToDateTime(long? timestamp)
        {
            if (!timestamp.HasValue)
            {
                return "Brak danych";
            }

            return DateTimeOffset.FromUnixTimeSeconds(timestamp.Value).ToLocalTime().ToString("HH:mm");
        }
    }

    class MainData
    {
        public double Temp { get; set; }
        public int Humidity { get; set; }
    }
    class WindData
    {
        public double Speed { get; set; }
        public int Deg { get; set; }
    }
    class RainData
    {
        public double OneHour { get; set; }
    }
    class CloudData
    {
        public int All { get; set; }
    }
    class SysData
    {
        public long Sunrise { get; set; }
        public long Sunset { get; set; }
    }
    class WeatherDescription
    {
        public string Description { get; set; }
    }
}
