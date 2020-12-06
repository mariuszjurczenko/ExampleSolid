namespace ExampleSolid
{
    internal class DefaultContext : ICarWashContext
    {
        private readonly IDetailsSource _detailsSource;

        public CarWash CarWash { get; set; }

        public DefaultContext(IDetailsSource detailsSource)
        {
            _detailsSource = detailsSource;
        }

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
            return _detailsSource.GetDetailsFromSource();
        }

        public string LoadDetailsFromURI(string uri)
        {
            throw new System.NotImplementedException();
        }

        public void Log(string message)
        {
            new ConsoleLogger().Log(message);
        }
    }
}