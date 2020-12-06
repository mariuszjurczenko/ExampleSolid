using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ExampleSolid
{
    public class JsonDetailsSerializer 
    {
        public Details GetDetailsFromJsonString(string jsonString)
        {
            return JsonConvert.DeserializeObject<Details>(jsonString, new StringEnumConverter());
        }
    }
}
