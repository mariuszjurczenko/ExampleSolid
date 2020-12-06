namespace ExampleSolid.Test
{
    public class FakeDetailsSource : IDetailsSource
    {
        public string DetailsString { get; set; }
        public string GetDetailsFromSource()
        {
            return DetailsString;
        }
    }
}
