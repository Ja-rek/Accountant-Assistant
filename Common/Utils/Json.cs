using Newtonsoft.Json;

namespace Common.Utils
{
    public static class Json
    {
        public static string Serialize(object obj)
        {
            return "\r" + JsonConvert.SerializeObject(obj, Formatting.Indented);
        }
    }
}
