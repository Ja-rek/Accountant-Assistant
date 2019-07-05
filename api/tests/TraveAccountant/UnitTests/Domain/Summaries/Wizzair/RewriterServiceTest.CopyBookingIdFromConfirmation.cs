using System;
using NUnit.Framework;
using TravelAccountant.Domain.Summaries.Wizzair;

namespace TravelAccountant.UnitTests.Domain.Summaries.Wizzair
{
    internal partial class RewriterServiceTest 
    {
        [Test]
        public void CopyBookingIdFromConfirmation_WhenConfirmationHasCorrectFormat_ThenReturnsCorrectValue()
        {
            var rewriterService = new RewriterService(StubConfirmation.PLNVersion());

            var actualTravelNumber = rewriterService.CopyBookingIdFromConfirmation();

            Assert.AreEqual("U576YR", actualTravelNumber);
        }

        [Test]
        public void CopyBookingIdFromConfirmation_WhenConfirmationHasIncorrectFormat_ThenThrowsApplicationException()
        {
            var rewriterService = new RewriterService(StubConfirmation.IncorrectFormat());

            Assert.Throws<ApplicationException>(() => rewriterService.CopyBookingIdFromConfirmation());
        }
    }
}
