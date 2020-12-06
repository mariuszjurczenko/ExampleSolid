using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.IO;

namespace ExampleSolid
{
    /// <summary>
    /// CarWash odczytuje szczegóły mycia z pliku i tworzy wycene mycia na podstawie szczegółów.
    /// </summary>
    public class CarWash
    {
        public decimal WashingCost { get; set; } 

        public void Pricing()
        {
            Console.WriteLine("Starting pricing.");
            Console.WriteLine("Loading details.");

            string detailsJson = File.ReadAllText("details.json");

            var details = JsonConvert.DeserializeObject<Details>(detailsJson, new StringEnumConverter());

            switch (details.WashingType)
            {
                case WashingType.Standard:
                    Console.WriteLine("Valuation for a standartd program.");
                    Console.WriteLine("Valuation rules.");
                    if (String.IsNullOrEmpty(details.Make))
                    {
                        Console.WriteLine("Car make must be stated.");
                        return;
                    }
                    decimal baseWashingCost = 20 ;
                    if (details.Make == "Ferrari")
                    {
                        baseWashingCost = baseWashingCost * 3;
                    }
                    baseWashingCost += details.Rinsing;
                    baseWashingCost += details.Drying;
                    WashingCost = baseWashingCost;                   
                    break;

                case WashingType.StandardPlus:
                    Console.WriteLine("Valuation for a standartd plus program.");
                    Console.WriteLine("Valuation rules.");
                    if (String.IsNullOrEmpty(details.Make))
                    {
                        Console.WriteLine("Car make must be stated");
                        return;
                    }
                    if (details.VacuumingInside == 0 || details.WashingInside == 0)
                    {
                        Console.WriteLine("Standard Plus must specify Vacuuming Inside and Washing Inside.");
                        return;
                    }
                    baseWashingCost = 25;
                    if (details.Make == "Ferrari")
                    {
                        baseWashingCost = baseWashingCost * 3;
                    }
                    if (details.Make == "Ford")
                    {
                        baseWashingCost = baseWashingCost * 1.5m;
                    }
                    baseWashingCost += details.VacuumingInside;
                    baseWashingCost += details.WashingInside;
                    WashingCost = baseWashingCost;
                    break;

                case WashingType.Waxing:
                    Console.WriteLine("Valuation for a waxing program.");
                    Console.WriteLine("Valuation rules.");
                    baseWashingCost = 40;
                    if (details.Double)
                    {
                        baseWashingCost = baseWashingCost * 3;
                    }
                    WashingCost = baseWashingCost;
                    break;

                default:
                    Console.WriteLine("Unknown type of Washing.");
                    break;
            }

            Console.WriteLine("Pricing completed.");
        }
    }
}
