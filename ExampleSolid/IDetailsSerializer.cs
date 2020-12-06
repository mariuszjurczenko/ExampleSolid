namespace ExampleSolid
{
    public interface IDetailsSerializer
    {
        Details GetDetailsFromJsonString(string jsonString);
    }
}
