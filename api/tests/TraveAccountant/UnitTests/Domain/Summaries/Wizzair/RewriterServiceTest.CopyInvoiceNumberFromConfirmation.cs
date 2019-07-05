using System;
using NUnit.Framework;
using TravelAccountant.Domain.Summaries.Wizzair;

namespace TravelAccountant.UnitTests.Domain.Summaries.Wizzair
{
    internal partial class RewriterServiceTest 
    {
        [Test]
        public void CopyInvocieNumberFromConfirmation_WhenConfirmationHasCorrectFormat_ThenReturnsCorrectValue()
        {
            var rewriterService = new RewriterService(StubConfirmation.PLNVersion());

            var actualTravelNumber = rewriterService.CopyInvocieNumberFromConfirmation();

            Assert.AreEqual("053683790Z", actualTravelNumber);
        }

        [Test]
        public void CopyInvocieNumberFromConfirmation_WhenConfirmationHasIncorrectFormat_ThenThrowsApplicationException()
        {
            var rewriterService = new RewriterService(StubConfirmation.IncorrectFormat());

            Assert.Throws<ApplicationException>(() => rewriterService.CopyBookingIdFromConfirmation());
        }
    }
}
