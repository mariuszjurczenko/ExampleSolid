namespace ExampleSolid
{
    /// <summary>
    /// CarWash odczytuje szczegóły mycia z pliku i tworzy wycene mycia na podstawie szczegółów.
    /// </summary>
    public class CarWash
    {
        public decimal WashingCost { get; set; }
        public ICarWashContext Context { get; set; } = new DefaultContext();

        public CarWash()
        {
            Context.CarWash = this;
        }

        public void Pricing()
        {
            Context.Log("Starting pricing.");
            Context.Log("Loading details.");

            string detailsJson = Context.LoadDetailsFromFile();

            var details = Context.GetDetailsFromJsonString(detailsJson);

            var pricing = Context.CreateDetailsPricingForDetails(details, Context);

            pricing.Pricing(details);

            Context.Log("Pricing completed.");
        }
    }
}
