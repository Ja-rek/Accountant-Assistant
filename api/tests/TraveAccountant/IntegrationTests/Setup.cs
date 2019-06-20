using NUnit.Framework;
using NLog;
using Common;

namespace TravelAccountant.IntegrationTests
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
