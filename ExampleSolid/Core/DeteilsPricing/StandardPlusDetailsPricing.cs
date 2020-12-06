using System;

namespace ExampleSolid
{
    public class StandardPlusDetailsPricing : DetailsPricing
    {
        public StandardPlusDetailsPricing(ILogger logger) : base(logger)
        {
        }

        public override decimal Pricing(Details details)
        {
            Logger.Log("Valuation for a standartd plus program.");
            Logger.Log("Valuation rules.");
            if (String.IsNullOrEmpty(details.Make))
            {
                Logger.Log("Car make must be stated");
                return 0;
            }
            if (details.VacuumingInside == 0 || details.WashingInside == 0)
            {
                Logger.Log("Standard Plus must specify Vacuuming Inside and Washing Inside.");
                return 0;
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
            return baseWashingCost;
        }
    }
}
