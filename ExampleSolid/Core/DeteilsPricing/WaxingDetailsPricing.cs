namespace ExampleSolid
{
    public class WaxingDetailsPricing : DetailsPricing
    {
        public WaxingDetailsPricing(ILogger logger) : base(logger)
        {
        }

        public override decimal Pricing(Details details)
        {
            Logger.Log("Valuation for a waxing program.");
            Logger.Log("Valuation rules.");
            decimal baseWashingCost = 40;
            if (details.Double)
            {
                baseWashingCost = baseWashingCost * 3;
            }
            return baseWashingCost;
        }
    }
}

