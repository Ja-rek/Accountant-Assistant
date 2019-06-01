using System;
using NUnit.Framework;
using TravelAccountant.Domain.Summaries.Ryanair;

namespace TravelAccountant.UnitTests.Domain.Summaries.Ryanair
{
    internal partial class RewriterServiceTest 
    {
        [Test]
        public void CopyTravelNumberFromConfirmation_WhenConfirmationHasCorrectFormat_ThenReturnsCorrectValue()
        {
            var rewriterService = new RewriterService(StubConfirmation.PLNVersion());

            var actualTravelNumber = rewriterService.CopyTravelNumberFromConfirmation();

            Assert.AreEqual("HTG93P", actualTravelNumber);
        }

        [Test]
        public void CopyTravelNumberFromConfirmation_WhenConfirmationHasIncorrectFormat_ThenThrowsApplicationException()
        {
            var rewriterService = new RewriterService(StubConfirmation.IncorrectFormat());

            Assert.Throws<ApplicationException>(() => rewriterService.CopyTravelNumberFromConfirmation());
        }
    }
}
