using System;

class Program
{
    static async Task Main()
    {
        Console.Clear();
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
}