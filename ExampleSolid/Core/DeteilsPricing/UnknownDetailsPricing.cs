namespace ExampleSolid
{
    public class UnknownDetailsPricing : DetailsPricing
    {
        public UnknownDetailsPricing(ILogger logger) : base(logger)
        {
        }

        public override decimal Pricing(Details details)
        {
            Logger.Log("Unknown type of Washing.");
            return 0;
        }
    }
}
