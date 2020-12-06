using Newtonsoft.Json;
using NUnit.Framework;
using System.IO;

namespace ExampleSolid.Test
{
    public class CarWashTest
    {
        private CarWash carWash;
        private FakeLogger logger;
        public CarWashTest()
        {
            logger = new FakeLogger();
            carWash = new CarWash(logger);
        }

        [Test]
        public void ReturnsPricingOf77ForWashingTypeStandardOf20RinsingOf7DryingOf10MakeOfFerrari()     
        {
            var details = new Details
            {
                WashingType = WashingType.Standard,
                Make = "Ferrari",
                Rinsing = 7,
                Drying = 10
            };
            string json = JsonConvert.SerializeObject(details);
            File.WriteAllText("details.json", json);

            carWash.Pricing();
            var result = carWash.WashingCost;

            Assert.AreEqual(77, result);
        }

        [Test]
        public void ReturnsPricingOf37ForWashingTypeStandardOf20RinsingOf7DryingOf10()
        {
            var details = new Details
            {
                WashingType = WashingType.Standard,
                Make = "Mazda",
                Rinsing = 7,
                Drying = 10
            };
            string json = JsonConvert.SerializeObject(details);
            File.WriteAllText("details.json", json);

            carWash.Pricing();
            var result = carWash.WashingCost;

            Assert.AreEqual(37, result);
        }

        [Test]
        public void ReturnsPricingOf0ForMakeNull()     
        {
            var details = new Details
            {
                WashingType = WashingType.StandardPlus,
                VacuumingInside = 15,
                WashingInside = 20,
            };
            string json = JsonConvert.SerializeObject(details);
            File.WriteAllText("details.json", json);

            carWash = new CarWash(logger);
            carWash.Pricing();
            var result = carWash.WashingCost;

            Assert.AreEqual(0, result);
        }

        [Test]
        public void LogsStartingLoadingAndCompleting() 
        {
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