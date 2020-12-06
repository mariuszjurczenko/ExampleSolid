 using System;

namespace ExampleSolid
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Car Wash Starting...");

            var carWash = new CarWash(new ConsoleLogger());
            carWash.Pricing();

            if (carWash.WashingCost > 0)
            {
                Console.WriteLine($"Washing Cost: {carWash.WashingCost}");
            }
            else
            {
                Console.WriteLine("No cost.");
            }

            Console.WriteLine("Car Wash Ending...");
            Console.WriteLine("See you soon!");
        }
    }
}
