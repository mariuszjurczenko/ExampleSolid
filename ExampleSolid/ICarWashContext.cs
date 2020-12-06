namespace ExampleSolid
{
    public interface ICarWashContext : ILogger
    {
        string LoadDetailsFromFile();
        string LoadDetailsFromURI(string uri);
        Details GetDetailsFromJsonString(string detailsJson);
        Details GetDetailsFromXmlString(string detailsXml);
        DetailsPricing CreateDetailsPricingForDetails(Details details, ICarWashContext context);
        CarWash CarWash { get; set; }
    }
}