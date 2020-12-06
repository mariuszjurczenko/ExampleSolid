using ExampleSolid;

namespace ExampleSolid.Test
{
    class FakeCarWashUpdater : ICarWashUpdater
    {
        public decimal? NewWashingCost { get; set; }
        public void UpdateWashingCost(decimal washingCost)
        {
            NewWashingCost = washingCost;
        }
    }
}
