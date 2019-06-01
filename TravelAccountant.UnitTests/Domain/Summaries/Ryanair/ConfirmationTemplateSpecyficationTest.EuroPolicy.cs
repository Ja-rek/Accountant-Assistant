using NUnit.Framework;
using TravelAccountant.Domain.Summaries.Ryanair;
using TravelAccountant.Domain.Summaries.Ryanair.ConfirmationTemplate.CurrencyPolicies;

namespace TravelAccountant.UnitTests.Domain.Summaries.Ryanair
{
    internal partial class ConfirmationTemplateSpecyficationTest
    {
        [Test]
        public void IsTemplateCorrect_WhenTemplateInEuroVersionIsCorrect_ThenReturnsTrue()
        {
            var specyficationEuro = new ConfirmationTemplateSpecyfication(new EuroPolicy());

            Assert.True(specyficationEuro.IsTemplateCorrect(StubConfirmation.EURVersion()));
        }

        [Test]
        public void IsTemplateCorrect_WhenTemplateInEuroVersionIsInOtherFormat_ThenReturnsFalse()
        {
            var specyficationEuro = new ConfirmationTemplateSpecyfication(new EuroPolicy());

            Assert.False(specyficationEuro.IsTemplateCorrect(StubConfirmation.PLNVersion()));
        }

        [Test]
        public void IsTemplateCorrect_WhenTemplateInEuroVersionIsIncorrect_ThenReturnsFalse()
        {
            var specyficationEuro = new ConfirmationTemplateSpecyfication(new EuroPolicy());

            Assert.False(specyficationEuro.IsTemplateCorrect(StubConfirmation.IncorrectFormat()));
        }
    }
}
