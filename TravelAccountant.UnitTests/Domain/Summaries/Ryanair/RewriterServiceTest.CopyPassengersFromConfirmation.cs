using System;
using NUnit.Framework;
using TravelAccountant.Domain.Summaries.Ryanair;

namespace TravelAccountant.UnitTests.Domain.Summaries.Ryanair
{
    internal partial class RewriterServiceTest 
    {
        [Test]
        public void CopyPassengersFromConfirmation_WhenConfirmationHasCorrectFormat_ThenReturnsCorrectValue()
        {
            var rewriterService = new RewriterService(StubConfirmation.PLNVersion());

            var actualPassengers = rewriterService.CopyPassengersFromConfirmation();

            Assert.AreEqual(expectedPassengers, actualPassengers);
        }

        [Test]
        public void CopyPassengersFromConfirmation_WhenConfirmationHasIncorrectFormat_ThenThrowsApplicationException()
        {
            var rewriterService = new RewriterService(StubConfirmation.IncorrectFormat());

            Assert.Throws<ApplicationException>(() => rewriterService.CopyPassengersFromConfirmation());
        }

        private static string[] expectedPassengers = new string[] 
        {
            "IZABELA MARCINKOWSKA KOWALSKA",
            "PIOTR KOWALSKI",
            "MAJA KOWALSKA-PETERSKA"
        };
    }
}
