using Newtonsoft.Json;
using NUnit.Framework;
using System.IO;

namespace ExampleSolid.Test
{
    public class CarWashTest
    {
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

            var carWash = new CarWash();
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

            var carWash = new CarWash();
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

            var carWash = new CarWash();
            carWash.Pricing();
            var result = carWash.WashingCost;

            Assert.AreEqual(0, result);
        }     
    }
}