using System;

namespace ExampleSolid
{
    public class PremiumDetailsPricing : DetailsPricing
    {
        public PremiumDetailsPricing(ICarWashContext context) : base(context)
        {
        }

        public override void Pricing(Details details)
        {
            Logger.Log("Valuation for a premium program.");
            Logger.Log("Valuation rules.");
            if (String.IsNullOrEmpty(details.Make))
            {
                Logger.Log("Car make must be stated.");
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
            _context.UpdateWashingCost(baseWashingCost);
        }
    }
}