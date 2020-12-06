namespace ExampleSolid
{
    public class UnknownDetailsPricing : DetailsPricing
    {
        public UnknownDetailsPricing(ICarWashContext context) : base(context)
        {
        }

        public override void Pricing(Details details)
        {
            Logger.Log("Unknown type of Washing.");
        }
    }
}
