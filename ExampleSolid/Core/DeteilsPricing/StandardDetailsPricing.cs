using System;

namespace ExampleSolid
{
    public class StandardDetailsPricing : DetailsPricing
    {
        public StandardDetailsPricing(ICarWashUpdater carWashUpdater) : base(carWashUpdater)
        {
        }

        public override void Pricing(Details details)
        {
            Logger.Log("Valuation for a standartd program.");
            Logger.Log("Valuation rules.");
            if (String.IsNullOrEmpty(details.Make))
            {
                Logger.Log("Car make must be stated.");
                return;
            }
            decimal baseWashingCost = 20;
            if (details.Make == "Ferrari")
            {
                baseWashingCost = baseWashingCost * 3;
            }
            baseWashingCost += details.Rinsing;
            baseWashingCost += details.Drying;
            _carWashUpdater.UpdateWashingCost(baseWashingCost);
        }
    }
}

