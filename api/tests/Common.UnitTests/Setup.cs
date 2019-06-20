using NUnit.Framework;
using NLog;

namespace Common.UnitTests
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
