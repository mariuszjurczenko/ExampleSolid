using ExampleSolid;
using NUnit.Framework;
using System.Linq;

namespace ExampleSolidTest
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

    }
}
