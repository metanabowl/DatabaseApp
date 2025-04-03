using DatabaseApp;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

internal class Program
{
    private static async Task Main(string[] args)
    {
        Console.Write("Podaj nazwę miasta: ");
        string city = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(city))
        {
            Console.WriteLine("Nie podano nazwy miasta.");
            return;
        }

        APITest apiTest = new APITest();
        await apiTest.GetWeatherByCity(city);

    }
}

