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
        private readonly DetailsPricingFactory _detailsPricingFactory;

        public decimal WashingCost { get; set; }
        public ICarWashContext Context { get; set; }

        public CarWash(ILogger logger, IDetailsSource detailsSource, IDetailsSerializer detailsSerializer, DetailsPricingFactory detailsPricingFactory)
        {
            _logger = logger;
            _detailsSource = detailsSource;
            _detailsSerializer = detailsSerializer;
            _detailsPricingFactory = detailsPricingFactory;
            Context = new DefaultContext(_detailsSource, _detailsSerializer);
            Context.CarWash = this;
        }

        public void Pricing()
        {
            _logger.Log("Starting pricing.");
            _logger.Log("Loading details.");

            string detailsJson = _detailsSource.GetDetailsFromSource();

            var details = _detailsSerializer.GetDetailsFromJsonString(detailsJson);

            var pricing = _detailsPricingFactory.Create(details, Context); 

            WashingCost = pricing.Pricing(details);

            _logger.Log("Pricing completed.");
        }
    }
}
