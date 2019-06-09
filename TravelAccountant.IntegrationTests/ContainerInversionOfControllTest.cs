using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using TravelAccountant.Application;
using TravelAccountant.Domain.Confirmations;
using TravelAccountant.Domain.Summaries;
using TravelAccountant.Domain.Summaries.Ryanair;

namespace TravelAccountant.IntegrationTests
{
    internal class ContainerInversionOfControllTest
    {
        [Test]
        public void Autofac_WhenCanResolveAllApplicationServices_ThenItMeansThatAutofacIsIntegtatedCorreclyWithApplication()
        {
            Assert.DoesNotThrow(() => ServiceLocator.Resolve<SummaryApplicationService<ConfirmationEmail>>());
        }
    }
}
