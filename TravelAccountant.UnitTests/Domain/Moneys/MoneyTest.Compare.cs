using TravelAccountant.Domain.Moneys;
using NUnit.Framework;

namespace TravelAccountant.UnitTests.Domain.Moneys
{
    internal partial class MoneyTest
    {
        [Test]
        public void Compare_WhenCompareAmountWithDiffrentCurrency_ThenReturnsFalse()
        {
            var amountPln = new Money(5, Currency.PLN);
            var amountEuro = new Money(5, Currency.EURO);

            Assert.False(amountPln == amountEuro);
            Assert.True(amountPln != amountEuro);
            Assert.False(amountPln.Equals(amountEuro));
        }

        [Test]
        public void Compare_WhenCompareAmountWithTheSameCurrency_ThenReturnsTrue()
        {
            var amountPln = new Money(5, Currency.PLN);
            var secountAmountPLN = new Money(5, Currency.PLN);

            Assert.True(amountPln == secountAmountPLN);
            Assert.False(amountPln != secountAmountPLN);
            Assert.True(amountPln.Equals(secountAmountPLN));
        }

        [Test]
        public void Compare_WhenCompareAmountWithDiffrentValue_ThenReturnsFalse()
        {
            var amountLessValue = new Money(5, Currency.PLN);
            var amountMoreValue = new Money(15, Currency.PLN);

            Assert.False(amountLessValue == amountMoreValue);
            Assert.True(amountLessValue != amountMoreValue);
            Assert.False(amountLessValue.Equals(amountMoreValue));
        }

        [Test]
        public void Compare_WhenCompareAmountWithTheSameValue_ThenReturnsTrue()
        {
            var amount = new Money(5, Currency.PLN);
            var secountAmount = new Money(5, Currency.PLN);

            Assert.True(amount == secountAmount);
            Assert.False(amount != secountAmount);
            Assert.True(amount.Equals(secountAmount));
        }
    }
}
