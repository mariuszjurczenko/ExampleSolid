namespace ExampleSolid
{
    public class WaxingDetailsPricing
    {
        private readonly CarWash _carWash;
        private ConsoleLogger _logger;

        public WaxingDetailsPricing(CarWash carWash, ConsoleLogger logger)
        {
            _carWash = carWash;
            _logger = logger;
        }

        public void Pricing(Details details)
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

