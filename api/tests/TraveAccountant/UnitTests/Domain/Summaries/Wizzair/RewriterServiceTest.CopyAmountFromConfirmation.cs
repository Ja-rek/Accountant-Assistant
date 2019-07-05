using System;
using NUnit.Framework;
using TravelAccountant.Domain.Summaries.Wizzair;
using TravelAccountant.Domain.Summaries.Wizzair.CurrencyPolicies;

namespace TravelAccountant.UnitTests.Domain.Summaries.Wizzair
{
    internal partial class RewriterServiceTest
    {
        [Test]
        public void CopyAmountFromConfirmation_WhenConfirmationContainAmountInPlnFormat_ThenReturnsCorrectValue()
        {
            var plnPolicy = new PlnPolicy();
            var rewriterService = new RewriterService(StubConfirmation.PLNVersion());

            var actualAmount = rewriterService.CopyAmountFromConfirmation(plnPolicy);

            Assert.AreEqual(expected: 161.96m, actualAmount.Value);
        }

        [Test]
        public void CopyAmountFromConfirmation_WhenConfirmationContainAmountInEuroFormat_ThenReturnsCorrectValue()
        {
            var euroPolicy = new EuroPolicy();
            var rewriterService = new RewriterService(StubConfirmation.EURVersion());
            Console.WriteLine(StubConfirmation.EURVersion().Content);

            var actualAmount = rewriterService.CopyAmountFromConfirmation(euroPolicy);

            Assert.AreEqual(expected: 161.96m, actualAmount.Value);
        }

        [Test]
        public void CopyAmountFromConfirmation_WhenConfirmationHasIncorrectFormat_ThenThrowsApplicationException()
        {
            var euroPolicy = new EuroPolicy();
            var rewriterService = new RewriterService(StubConfirmation.IncorrectFormat());

            Assert.Throws<ApplicationException>(() => rewriterService.CopyAmountFromConfirmation(euroPolicy));
        }
    }
}
