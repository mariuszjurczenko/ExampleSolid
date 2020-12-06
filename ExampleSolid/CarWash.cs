namespace ExampleSolid
{
    /// <summary>
    /// CarWash odczytuje szczegóły mycia z pliku i tworzy wycene mycia na podstawie szczegółów.
    /// </summary>
    public class CarWash
    {
        private readonly ILogger _logger;
        private readonly IDetailsSource _detailsSource;
        public decimal WashingCost { get; set; }
        public ICarWashContext Context { get; set; }

        public CarWash(ILogger logger, IDetailsSource detailsSource)
        {
            _logger = logger;
            _detailsSource = detailsSource;
            Context = new DefaultContext(_detailsSource);
            Context.CarWash = this;
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
