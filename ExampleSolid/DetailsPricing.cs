namespace ExampleSolid
{
    public abstract class DetailsPricing
    {
        protected readonly ICarWashContext _context;
        protected readonly ConsoleLogger _logger;

        public DetailsPricing(ICarWashContext context)
        {
            _context = context;
            _logger = context.Logger;
        }
        public abstract void Pricing(Details details);
    }
}