namespace ExampleSolid
{
    internal class DefaultContext : ICarWashContext
    {
        public CarWash CarWash { get; set; }

        public ConsoleLogger Logger => new ConsoleLogger();

        public DetailsPricing CreateDetailsPricingForDetails(Details details, ICarWashContext context)
        {
            return new DetailsPricingFactory().Create(details, context);
        }

        public Details GetDetailsFromJsonString(string detailsJson)
        {
            return new JsonDetailsSerializer().GetDetailsFromJsonString(detailsJson);
        }

        public Details GetDetailsFromXmlString(string detailsXml)
        {
            throw new System.NotImplementedException();
        }

        public string LoadDetailsFromFile()
        {
            return new FileDetailsSource().GetDetailsFromSource();
        }

        public string LoadDetailsFromURI(string uri)
        {
            throw new System.NotImplementedException();
        }

        public void Log(string message)
        {
            new ConsoleLogger().Log(message);
        }

        public void UpdateWashingCost(decimal washingCost)
        {
            CarWash.WashingCost = washingCost;
        }
    }
}