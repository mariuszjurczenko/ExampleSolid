﻿using NUnit.Framework;
using System.Linq;

namespace ExampleSolid.Test
{
    public class StandardDetailsPricingTest
    {
        [Test]
        public void LogsMakeRequiredMessageGivenDetailsWithoutMake() 
        {
            var details = new Details() { WashingType = WashingType.Standard };
            var logger = new FakeLogger();
            var pricing = new StandardDetailsPricing(null);
            pricing.Logger = logger;
            pricing.Pricing(details);

            Assert.AreEqual("Car make must be stated.", logger.LoggedMessages.Last());
        }

        [Test]
        public void SetsRatingTo1000ForBMWWith250Deductible()
        { 
            var logger = new FakeLogger();
            var details = new Details()
            {
                WashingType = WashingType.Standard,
                Make = "Ferari",
                Rinsing = 7,
                Drying = 10
            };

            var pricing = new StandardDetailsPricing(logger);

            Assert.AreEqual(37, pricing.Pricing(details));
        }
    }
}
