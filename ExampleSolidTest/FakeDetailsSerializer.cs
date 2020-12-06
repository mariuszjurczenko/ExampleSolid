namespace ExampleSolid.Test
{
    class FakeDetailsSerializer : IDetailsSerializer
    {
        public Details GetDetailsFromJsonString(string jsonString)
        {
            return new Details
            {
                WashingType = WashingType.Standard,
                Make = "Ferrari",
                Rinsing = 7,
                Drying = 10
            };
        }
    }
}
