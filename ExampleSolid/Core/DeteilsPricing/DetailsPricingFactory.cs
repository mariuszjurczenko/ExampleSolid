using System;

namespace ExampleSolid
{
    public class DetailsPricingFactory
    {
        private readonly ILogger _logger;

        public DetailsPricingFactory(ILogger logger)
        {
            _logger = logger;
        }

        public DetailsPricing Create(Details details, ICarWashContext context)
        {
            try
            {
                return (DetailsPricing)Activator.CreateInstance(
                            Type.GetType($"ExampleSolid.{details.WashingType}DetailsPricing"),
                                new object[] { _logger });
                 
            }
            catch (System.Exception)
            {
                return new UnknownDetailsPricing(_logger);
            }
        }
    }
}