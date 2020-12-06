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

            var factory = new DetailsPricingFactory();

            var pricing = factory.Create(details, this);

            pricing.Pricing(details);

            Logger.Log("Pricing completed.");
        }
    }
}
