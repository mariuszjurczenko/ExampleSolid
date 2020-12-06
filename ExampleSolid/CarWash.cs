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
        public ConsoleLogger Logger { get; set; } = new ConsoleLogger();
        public FileDetailsSource DetailsSource { get; set; } = new FileDetailsSource();
        public JsonDetailsSerializer DetailsSerializer { get; set; } = new JsonDetailsSerializer();

        public void Pricing()
        {
            Logger.Log("Starting pricing.");
            Logger.Log("Loading details.");

            string detailsJson = DetailsSource.GetDetailsFromSource();

            var details = DetailsSerializer.GetDetailsFromJsonString(detailsJson);

            switch (details.WashingType)
            {
                case WashingType.Standard:
                    Logger.Log("Valuation for a standartd program.");
                    Logger.Log("Valuation rules.");
                    if (String.IsNullOrEmpty(details.Make))
                    {
                        Logger.Log("Car make must be stated.");
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
                    Logger.Log("Valuation for a standartd plus program.");
                    Logger.Log("Valuation rules.");
                    if (String.IsNullOrEmpty(details.Make))
                    {
                        Logger.Log("Car make must be stated");
                        return;
                    }
                    if (details.VacuumingInside == 0 || details.WashingInside == 0)
                    {
                        Logger.Log("Standard Plus must specify Vacuuming Inside and Washing Inside.");
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
                    Logger.Log("Valuation for a waxing program.");
                    Logger.Log("Valuation rules.");
                    baseWashingCost = 40;
                    if (details.Double)
                    {
                        baseWashingCost = baseWashingCost * 3;
                    }
                    WashingCost = baseWashingCost;
                    break;

                default:
                    Logger.Log("Unknown type of Washing.");
                    break;
            }

            Logger.Log("Pricing completed.");
        }
    }
}
