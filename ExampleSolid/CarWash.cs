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
                    var standard = new StandardDetailsPricing(this, this.Logger);
                    standard.Pricing(details);
                    break;

                case WashingType.StandardPlus:
                    var standardPlus = new StandardPlusDetailsPricing(this, this.Logger);
                    standardPlus.Pricing(details);
                    break;

                case WashingType.Waxing:
                    var waxing = new WaxingDetailsPricing(this, this.Logger);
                    waxing.Pricing(details);
                    break;

                default:
                    Logger.Log("Unknown type of Washing.");
                    break;
            }

            Logger.Log("Pricing completed.");
        }
    }
}
