using System;

namespace ExampleSolid
{
    public class StandardPlusDetailsPricing : DetailsPricing
    {
        public StandardPlusDetailsPricing(ICarWashContext context) : base(context)
        {
        }

        public override void Pricing(Details details)
        {
            _context.Log("Valuation for a standartd plus program.");
            _context.Log("Valuation rules.");
            if (String.IsNullOrEmpty(details.Make))
            {
                _context.Log("Car make must be stated");
                return;
            }
            if (details.VacuumingInside == 0 || details.WashingInside == 0)
            {
                _context.Log("Standard Plus must specify Vacuuming Inside and Washing Inside.");
                return;
            }
            decimal baseWashingCost = 25;
            if (details.Make == "Ferrari")
            {
                baseWashingCost = baseWashingCost * 3;
            }
            if (details.Make == "Ford")
            {
                baseWashingCost = baseWashingCost * 1.5m;
            }
            baseWashingCost += details.VacuumingInside;
            baseWashingCost += details.WashingInside;
            _context.UpdateWashingCost(baseWashingCost);
        }
    }
}
