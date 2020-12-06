namespace ExampleSolid
{
    public interface ICarWashContext
    {
        void Log(string message);
        string LoadDetailsFromFile();
        string LoadDetailsFromURI(string uri);
        Details GetDetailsFromJsonString(string detailsJson);
        Details GetDetailsFromXmlString(string detailsXml);
        DetailsPricing CreateDetailsPricingForDetails(Details details, ICarWashContext context);
        void UpdateWashingCost(decimal washingCost);
        CarWash CarWash { get; set; }
        ConsoleLogger Logger { get; }
    }
}