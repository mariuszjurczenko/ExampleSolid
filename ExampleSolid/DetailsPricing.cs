namespace ExampleSolid
{
    public abstract class DetailsPricing
    {
        protected readonly ICarWashContext _context;
        protected ILogger Logger { get; set; } = new ConsoleLogger();

        public DetailsPricing(ICarWashContext context)
        {
            _context = context;
        }
        public abstract void Pricing(Details details);
    }
}