namespace ExampleSolid
{
    public class Details
    {
        public WashingType WashingType { get; set; }
        public string Make { get; set; } 

        #region Standart
        public decimal Rinsing { get; set; }
        public decimal Drying { get; set; }
        #endregion

        #region StandartPlus
        public decimal VacuumingInside { get; set; }
        public decimal WashingInside { get; set; }  
        #endregion

        #region Waxing
        public bool Double { get; set; }
        #endregion

    }
}
