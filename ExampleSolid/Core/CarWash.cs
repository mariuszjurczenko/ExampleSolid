namespace ExampleSolid
{
    /// <summary>
    /// CarWash odczytuje szczegóły mycia z pliku i tworzy wycene mycia na podstawie szczegółów.
    /// </summary>
    public class CarWash
    {
        private readonly ILogger _logger;
        private readonly IDetailsSource _detailsSource;
        private readonly IDetailsSerializer _detailsSerializer;

        public decimal WashingCost { get; set; }
        public ICarWashContext Context { get; set; }

        public CarWash(ILogger logger, IDetailsSource detailsSource, IDetailsSerializer detailsSerializer)
        {
            _logger = logger;
            _detailsSource = detailsSource;
            _detailsSerializer = detailsSerializer;
            Context = new DefaultContext(_detailsSource, _detailsSerializer);
            Context.CarWash = this;
        }

        public void Pricing()
        {
            _logger.Log("Starting pricing.");
            _logger.Log("Loading details.");

            string detailsJson = _detailsSource.GetDetailsFromSource();

            var details = _detailsSerializer.GetDetailsFromJsonString(detailsJson);

            var pricing = Context.CreateDetailsPricingForDetails(details, Context);

            pricing.Pricing(details);

            _logger.Log("Pricing completed.");
        }
    }
}
