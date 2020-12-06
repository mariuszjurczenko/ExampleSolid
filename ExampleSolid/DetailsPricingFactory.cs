using System;

namespace ExampleSolid
{
    public class DetailsPricingFactory
    {
        public DetailsPricing Create(Details details, CarWash carWash)
        {
            try
            {
                return (DetailsPricing)Activator.CreateInstance(
                            Type.GetType($"ExampleSolid.{details.WashingType}DetailsPricing"),
                                new object[] { carWash, carWash.Logger });
                 
            }
            catch (System.Exception)
            {
                return new UnknownDetailsPricing(carWash, carWash.Logger);
            }
        }
    }
}