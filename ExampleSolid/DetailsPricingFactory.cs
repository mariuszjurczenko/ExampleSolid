namespace ExampleSolid
{
    public class DetailsPricingFactory
    {
        public DetailsPricing Create(Details details, CarWash carWash)
        {
            switch (details.WashingType)
            {
                case WashingType.Standard:
                    return new StandardDetailsPricing(carWash, carWash.Logger);

                case WashingType.StandardPlus:
                    return new StandardPlusDetailsPricing(carWash, carWash.Logger);

                case WashingType.Waxing:
                    return new WaxingDetailsPricing(carWash, carWash.Logger);

                default:
                    return null;
            }
        }
    }
}