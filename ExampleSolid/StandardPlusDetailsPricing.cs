using System;

namespace ExampleSolid
{
    public class StandardPlusDetailsPricing
    {
        private readonly CarWash _carWash;
        private ConsoleLogger _logger;

        public StandardPlusDetailsPricing(CarWash carWash, ConsoleLogger logger)
        {
            _carWash = carWash;
            _logger = logger;
        }

        public void Pricing(Details details)
        {
            _logger.Log("Valuation for a standartd plus program.");
            _logger.Log("Valuation rules.");
            if (String.IsNullOrEmpty(details.Make))
            {
                _logger.Log("Car make must be stated");
                return;
            }
            if (details.VacuumingInside == 0 || details.WashingInside == 0)
            {
                _logger.Log("Standard Plus must specify Vacuuming Inside and Washing Inside.");
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
            _carWash.WashingCost = baseWashingCost;
        }
    }
}
