namespace ExampleSolid
{
    public class WaxingDetailsPricing : DetailsPricing
    {
        public WaxingDetailsPricing(ICarWashContext context) : base(context)
        {
        }

        public override void Pricing(Details details)
        {
            Logger.Log("Valuation for a waxing program.");
            Logger.Log("Valuation rules.");
            decimal baseWashingCost = 40;
            if (details.Double)
            {
                baseWashingCost = baseWashingCost * 3;
            }
            _context.UpdateWashingCost(baseWashingCost);
        }
    }
}

