using Newtonsoft.Json;
using NUnit.Framework;
using System.IO;

namespace ExampleSolid.Test
{
    public class CarWashTest
    {
        private CarWash carWash;
        private FakeLogger logger;
        private FakeDetailsSource detailsSource;
        private FakeDetailsSerializer detailsSerializer;
        private DetailsPricingFactory detailsPricingFactory;
        public CarWashTest()
        {
            logger = new FakeLogger();
            detailsSource = new FakeDetailsSource();
            detailsSerializer = new FakeDetailsSerializer();
            detailsPricingFactory = new DetailsPricingFactory(logger);
            carWash = new CarWash(logger, detailsSource, detailsSerializer, detailsPricingFactory);
        }

        [Test]
        public void ReturnsPricingOf77ForWashingTypeStandardOf20RinsingOf7DryingOf10MakeOfFerrari()     
        {
            detailsSource.DetailsString = "{\"WashingType\": \"Standard\", \"Make\": \"Ferrari\", \"Rinsing\": 7, \"Drying\": 10}";
            detailsSerializer.GetDetailsFromJsonString(detailsSource.DetailsString);
            carWash.Pricing();
            var result = carWash.WashingCost;

            Assert.AreEqual(77, result);
        }
      
        [Test]
        public void LogsStartingLoadingAndCompleting() 
        {
            detailsSource.DetailsString = "{\"WashingType\": \"Standard\", \"Make\": \"Ford\", \"Rinsing\": 7, \"Drying\": 10}";
            var details = new Details
            {
                WashingType = WashingType.Standard,
                Make = "Ford",
                Rinsing = 7,
                Drying = 10
            };
            string json = JsonConvert.SerializeObject(details);
            File.WriteAllText("details.json", json);

            carWash.Pricing();
            var result = carWash.WashingCost;

            Assert.Contains("Starting pricing.", logger.LoggedMessages);
            Assert.Contains("Loading details.", logger.LoggedMessages);
            Assert.Contains("Pricing completed.", logger.LoggedMessages);
        }
    }
}