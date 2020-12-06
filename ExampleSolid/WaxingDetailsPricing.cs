namespace ExampleSolid
{
    public class WaxingDetailsPricing : DetailsPricing
    {
        public WaxingDetailsPricing(CarWash carWash, ConsoleLogger logger) : base(carWash, logger)
        {
        }

        public override void Pricing(Details details)
        {
            _logger.Log("Valuation for a waxing program.");
            _logger.Log("Valuation rules.");
            decimal baseWashingCost = 40;
            if (details.Double)
            {
                baseWashingCost = baseWashingCost * 3;
            }
            _carWash.WashingCost = baseWashingCost;
        }
    }
}

