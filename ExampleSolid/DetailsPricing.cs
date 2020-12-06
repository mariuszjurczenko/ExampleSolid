namespace ExampleSolid
{
    public abstract class DetailsPricing
    {
        protected readonly ICarWashUpdater _carWashUpdater;
        public ILogger Logger { get; set; } = new ConsoleLogger();

        public DetailsPricing(ICarWashUpdater carWashUpdater) 
        {
            _carWashUpdater = carWashUpdater;
        }
        public abstract void Pricing(Details details);
    }
}