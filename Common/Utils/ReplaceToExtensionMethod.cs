using System.Linq;

namespace Common.Utils
{
    public static class ReplaceToExtensionMethod
    {
        public static string ReplaceAllTo(this string source, string newValue, params string[] oldValues)
        {
            string value = source.Replace(oldValues.First(), newValue);

            foreach (var oldValue in oldValues.Skip(1))
            {
                value = value.Replace(oldValue, newValue);
            }

            return value;
        }
    }
}
