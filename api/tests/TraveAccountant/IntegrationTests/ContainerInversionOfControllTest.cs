using NUnit.Framework;
using TravelAccountant.Application.Summaries;

namespace TravelAccountant.IntegrationTests
{
    internal class ContainerInversionOfControllTest
    {
        [Test]
        public void Autofac_WhenCanResolveAllApplicationServices_ThenItMeansThatAutofacIsIntegtatedCorreclyWithApplication()
        {
            Assert.DoesNotThrow(() => ServiceLocator.Resolve<SummaryApplicationService>());
        }
    }
}
