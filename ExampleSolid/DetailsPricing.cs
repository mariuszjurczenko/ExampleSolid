namespace ExampleSolid
{
    public abstract class DetailsPricing
    {
        protected readonly CarWash _carWash;
        protected readonly ConsoleLogger _logger;

        public DetailsPricing(CarWash carWash, ConsoleLogger logger)
        {
            _carWash = carWash;
            _logger = logger;
        }
        public abstract void Pricing(Details details);
    }
}