using System;

namespace ExampleSolid
{
    public class PremiumDetailsPricing : DetailsPricing
    {
        public PremiumDetailsPricing(CarWash carWash, ConsoleLogger logger) : base(carWash, logger)
        {
        }

        public override void Pricing(Details details)
        {
            _logger.Log("Valuation for a premium program.");
            _logger.Log("Valuation rules.");
            if (String.IsNullOrEmpty(details.Make))
            {
                _logger.Log("Car make must be stated.");
                return;
            }
            decimal baseWashingCost = 40;
            baseWashingCost += details.Rinsing * 2;
            baseWashingCost += details.Drying * 2;
            baseWashingCost += details.Coffee;
            if (details.Make == "Ferrari")
            {
                baseWashingCost = baseWashingCost * 2;
            }
            _carWash.WashingCost = baseWashingCost;
        }
    }
}