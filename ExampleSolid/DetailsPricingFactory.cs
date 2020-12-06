using System;

namespace ExampleSolid
{
    public class DetailsPricingFactory
    {
        public DetailsPricing Create(Details details, CarWash carWash)
        {
            try
            {
                var detailsPricing = (DetailsPricing)Activator.CreateInstance(
                                        Type.GetType($"ExampleSolid.{details.WashingType}DetailsPricing"),
                                            new object[] { carWash, carWash.Logger });
                return detailsPricing;
            }
            catch (System.Exception)
            {
                return null;
            }
        }
    }
}