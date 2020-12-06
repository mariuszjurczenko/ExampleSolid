using ExampleSolid;

namespace ExampleSolidTest
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
