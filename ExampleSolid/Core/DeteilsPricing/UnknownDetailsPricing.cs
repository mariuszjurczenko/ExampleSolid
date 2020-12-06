namespace ExampleSolid
{
    public class UnknownDetailsPricing : DetailsPricing
    {
        public UnknownDetailsPricing(ICarWashUpdater carWashUpdater) : base(carWashUpdater)
        {
        }

        public override void Pricing(Details details)
        {
            Logger.Log("Unknown type of Washing.");
        }
    }
}
