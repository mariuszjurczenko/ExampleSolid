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
            _context.Log("Valuation for a premium program.");
            _context.Log("Valuation rules.");
            if (String.IsNullOrEmpty(details.Make))
            {
                _context.Log("Car make must be stated.");
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