using NUnit.Framework;
using Common.Utils;

namespace Common.UnitTests.Utils
{
    internal class ReplaceToExtensionMethod
    {
        public void ReplaceAllTo_WhenReplaced_ThenReturnsCorrectValue()
        {
            var text = "Ala have a fat black cat.";

            var expectedValue = "Ala have a cat.";
            var actualValue = text.ReplaceAllTo(string.Empty, "fat", "black");

            Assert.AreEqual(expectedValue, actualValue);
        }
    }
}
