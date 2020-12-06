namespace ExampleSolid
{
    public class CarWashUpdater : ICarWashUpdater
    {
        private readonly CarWash _carWash;

        public CarWashUpdater(CarWash carWash)
        {
            _carWash = carWash;
        }

        public void UpdateWashingCost(decimal washingCost)
        {
            _carWash.WashingCost = washingCost;
        }
    }
}
