namespace ExampleSolid
{
    public interface ICarWashContext : ILogger, ICarWashUpdater
    {
        string LoadDetailsFromFile();
        string LoadDetailsFromURI(string uri);
        Details GetDetailsFromJsonString(string detailsJson);
        Details GetDetailsFromXmlString(string detailsXml);
        DetailsPricing CreateDetailsPricingForDetails(Details details, ICarWashContext context);
        CarWash CarWash { get; set; }
        ConsoleLogger Logger { get; }
    }
}