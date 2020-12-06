namespace ExampleSolid
{
    public class WaxingDetailsPricing : DetailsPricing
    {
        public WaxingDetailsPricing(ICarWashUpdater carWashUpdater) : base(carWashUpdater)
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
            _carWashUpdater.UpdateWashingCost(baseWashingCost);
        }
    }
}

