using System;

namespace ExampleSolid
{
    public class StandardDetailsPricing : DetailsPricing
    {
        public StandardDetailsPricing(CarWash carWash, ConsoleLogger logger) : base(carWash, logger)
        {
        }

        public override void Pricing(Details details)
        {
            _logger.Log("Valuation for a standartd program.");
            _logger.Log("Valuation rules.");
            if (String.IsNullOrEmpty(details.Make))
            {
                _logger.Log("Car make must be stated.");
                return;
            }
            decimal baseWashingCost = 20;
            if (details.Make == "Ferrari")
            {
                baseWashingCost = baseWashingCost * 3;
            }
            baseWashingCost += details.Rinsing;
            baseWashingCost += details.Drying;
            _carWash.WashingCost = baseWashingCost;
        }
    }
}

