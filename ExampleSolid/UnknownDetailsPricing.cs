namespace ExampleSolid
{
    public class UnknownDetailsPricing : DetailsPricing
    {
        public UnknownDetailsPricing(CarWash carWash, ConsoleLogger logger) : base(carWash, logger)
        {
        }

        public override void Pricing(Details details)
        {
            _logger.Log("Unknown type of Washing.");
        }
    }
}
