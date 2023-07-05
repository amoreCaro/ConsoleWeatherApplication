using System;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;

class Program
{
    static async Task Main()
    {
        Console.WriteLine("Welcome to the Weather Console App!");
        Console.WriteLine("-----------------------------------");
        Console.WriteLine("1. Get Weather");
        Console.WriteLine("2. Exit");
        Console.Write("Please enter your choice: ");

        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                await GetWeather();
                break;
            case "2":
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Invalid choice. Please try again.");
                break;
        }

        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    static async Task GetWeather()
    {
        string apiKey = "e5589729577b447387c131545230507"; //  WeatherAPI.com API key
        string location = "New York"; // Desired location

        string url = $"http://api.weatherapi.com/v1/current.json?key={apiKey}&q={location}";

        var client = new RestClient(url);
        var request = new RestRequest();
        var response = await client.ExecuteAsync(request);

        // Check if the API request was successful
        if (response.IsSuccessful)
        {
            // Deserialize the JSON response
            dynamic weatherData = JsonConvert.DeserializeObject(response.Content);
            
            // Extract the temperature and condition from the weather data
            double temperature = weatherData.current.temp_c;
            string condition = weatherData.current.condition.text;

            // Display the weather information
            Console.WriteLine($"Temperature: {temperature}°C");
            Console.WriteLine($"Condition: {condition}");
        }
        else
        {
            Console.WriteLine("Error occurred while retrieving weather data.");
        }
    }
}
