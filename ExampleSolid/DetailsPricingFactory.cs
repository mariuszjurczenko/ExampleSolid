using System;

namespace ExampleSolid
{
    public class DetailsPricingFactory
    {
        public DetailsPricing Create(Details details, ICarWashContext context)
        {
            try
            {
                return (DetailsPricing)Activator.CreateInstance(
                            Type.GetType($"ExampleSolid.{details.WashingType}DetailsPricing"),
                                new object[] { context });
                 
            }
            catch (System.Exception)
            {
                return new UnknownDetailsPricing(context);
            }
        }
    }
}