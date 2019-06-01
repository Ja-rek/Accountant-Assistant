using NUnit.Framework;
using NLog;
using Common;

namespace TravelAccountant.UnitTests
{
    [SetUpFixture]
    internal class Setup
    {
        [OneTimeSetUp]
        public void RunBeforeAnyTests()
        {
            LogManager.Configuration = LogConfig.Config();
        }
    }
}
