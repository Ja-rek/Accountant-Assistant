using NUnit.Framework;
using TravelAccountant.Domain.Summaries.Wizzair;
using TravelAccountant.Domain.Summaries.Wizzair.CurrencyPolicies;

namespace TravelAccountant.UnitTests.Domain.Summaries.Wizzair
{
    internal partial class ConfirmationTemplateSpecyficationTest
    {
        [Test]
        public void IsTemplateCorrect_WhenTemplateInPlnVersionIsCorrect_ThenReturnsTrue()
        {
            var specyficationEuro = new ConfirmationTemplateSpecyfication(new PlnPolicy());

            Assert.True(specyficationEuro.IsTemplateCorrect(StubConfirmation.PLNVersion()));
        }

        [Test]
        public void IsTemplateCorrect_WhenTemplateInPlnVersionIsInOtherFormat_ThenReturnsFalse()
        {
            var specyficationEuro = new ConfirmationTemplateSpecyfication(new PlnPolicy());

            Assert.False(specyficationEuro.IsTemplateCorrect(StubConfirmation.EURVersion()));
        }

        [Test]
        public void IsTemplateCorrect_WhenTemplateInPlnVersionIsIncorrect_ThenReturnsFalse()
        {
            var specyficationEuro = new ConfirmationTemplateSpecyfication(new PlnPolicy());

            Assert.False(specyficationEuro.IsTemplateCorrect(StubConfirmation.IncorrectFormat()));
        }
    }
}
