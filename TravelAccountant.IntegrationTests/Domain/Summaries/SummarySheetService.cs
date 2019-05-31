using NUnit.Framework;
using TravelAccountant.Domain.Summaries;

namespace TravelAccountant.IntegrationTests.Domain.Summaries
{
    internal class SummarySheetServiceTest
    {
        [Test]
        public void Test()
        {
            var summary = SummaryShetService();

            Assert.Pass();
        }

        public ISummarySheetService SummaryShetService()
        {
            return ServiceLocator.Resolve<ISummarySheetService>();
        }
    }
}
