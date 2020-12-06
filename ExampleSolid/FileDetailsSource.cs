using System.IO;

namespace ExampleSolid
{
    public class FileDetailsSource
    {
        public string GetDetailsFromSource() 
        {
            return File.ReadAllText("details.json");
        }
    }
}
