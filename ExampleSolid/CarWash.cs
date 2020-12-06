namespace ExampleSolid
{
    /// <summary>
    /// CarWash odczytuje szczegóły mycia z pliku i tworzy wycene mycia na podstawie szczegółów.
    /// </summary>
    public class CarWash
    {
        private readonly ILogger _logger;
        public decimal WashingCost { get; set; }
        public ICarWashContext Context { get; set; } = new DefaultContext();

        public CarWash(ILogger logger)
        {
            Context.CarWash = this;
            _logger = logger;
        }

        public void Pricing()
        {
            _logger.Log("Starting pricing.");
            _logger.Log("Loading details.");

            string detailsJson = Context.LoadDetailsFromFile();

            var details = Context.GetDetailsFromJsonString(detailsJson);

            var pricing = Context.CreateDetailsPricingForDetails(details, Context);

            pricing.Pricing(details);

            _logger.Log("Pricing completed.");
        }
    }
}
