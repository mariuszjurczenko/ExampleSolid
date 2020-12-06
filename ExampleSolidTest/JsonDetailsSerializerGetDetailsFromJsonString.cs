using NUnit.Framework;

namespace ExampleSolid.Test
{
    public class JsonDetailsSerializerGetDetailsFromJsonString
    {
        [Test]
        public void ReturnsDefaultDetailsFromEmptyJsonString() 
        {
            var inputJson = "{}";
            var serializer = new JsonDetailsSerializer();

            var result = serializer.GetDetailsFromJsonString(inputJson);

            var details = new Details();
            AssertDetailsEqual(result, details);
        }

        [Test]
        public void ReturnsSimpleDetailsFromValidJsonString() 
        {
            var inputJson = @"{""WashingType"": ""Standard"",""Make"": ""Ferrari"",""Rinsing"": 7,""Drying"": 10}";
            var serializer = new JsonDetailsSerializer();

            var result = serializer.GetDetailsFromJsonString(inputJson);

            var details = new Details { WashingType = WashingType.Standard, Make = "Ferrari", Rinsing = 7, Drying = 10 };
            AssertDetailsEqual(result, details);
        }

        private static void AssertDetailsEqual(Details result, Details details)
        {
            Assert.AreEqual(details.Double, result.Double);
            Assert.AreEqual(details.Drying, result.Drying);
            Assert.AreEqual(details.Make, result.Make);
            Assert.AreEqual(details.Rinsing, result.Rinsing);
            Assert.AreEqual(details.VacuumingInside, result.VacuumingInside);
            Assert.AreEqual(details.WashingInside, result.WashingInside);
            Assert.AreEqual(details.WashingType, result.WashingType);
        }
    }
}
