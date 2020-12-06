namespace ExampleSolid
{
    public class UnknownDetailsPricing : DetailsPricing
    {
        public UnknownDetailsPricing(ICarWashContext context) : base(context)
        {
        }

        public override void Pricing(Details details)
        {
            _context.Log("Unknown type of Washing.");
        }
    }
}
