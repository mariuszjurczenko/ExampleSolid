namespace ExampleSolid
{
    public abstract class DetailsPricing
    {
        public ILogger Logger { get; set; } 

        public DetailsPricing(ILogger logger) 
        {
            Logger = logger;
        }
        public abstract decimal Pricing(Details details);
    }
}