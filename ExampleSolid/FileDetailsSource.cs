using System.IO;

namespace ExampleSolid
{
    public class FileDetailsSource : IDetailsSource
    {
        public string GetDetailsFromSource() 
        {
            return File.ReadAllText("details.json");
        }
    }
}
