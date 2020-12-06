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
        public CarWashTest()
        {
            logger = new FakeLogger();
            detailsSource = new FakeDetailsSource();
            carWash = new CarWash(logger, detailsSource);
        }

        [Test]
        public void ReturnsPricingOf77ForWashingTypeStandardOf20RinsingOf7DryingOf10MakeOfFerrari()     
        {
            detailsSource.DetailsString = "{\"WashingType\": \"Standard\", \"Make\": \"Ferrari\", \"Rinsing\": 7, \"Drying\": 10}";

            carWash.Pricing();
            var result = carWash.WashingCost;

            Assert.AreEqual(77, result);
        }

        [Test]
        public void ReturnsPricingOf37ForWashingTypeStandardOf20RinsingOf7DryingOf10()
        {
            detailsSource.DetailsString = "{\"WashingType\": \"Standard\", \"Make\": \"Mazda\", \"Rinsing\": 7, \"Drying\": 10}";

            carWash.Pricing();
            var result = carWash.WashingCost;

            Assert.AreEqual(37, result);
        }

        [Test]
        public void ReturnsPricingOf0ForMakeNull()     
        {
            detailsSource.DetailsString = "{\"WashingType\": \"StandardPlus\", \"VacuumingInside\": 15, \"WashingInside\": 20}";

            carWash = new CarWash(logger, detailsSource);
            carWash.Pricing();
            var result = carWash.WashingCost;

            Assert.AreEqual(0, result);
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