using System;
using TravelAccountant.Domain.Moneys;
using NUnit.Framework;

namespace TravelAccountant.UnitTests.Domain.Moneys
{
    internal partial class MoneyTest
    {
        [Test]
        public void Add_WhenAddAmountWithTheSameCurrency_ThenDoNotThrowException()
        {
            var amountPln = new Money(5, Currency.PLN);
            var secountAmountPln = new Money(5, Currency.PLN);

            var actual = amountPln + secountAmountPln;
            var expected = new Money(10, Currency.PLN);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Add_WhenAddAmountWithDiffrentCurrency_ThenThrowsException()
        {
            var amountPln = new Money(5, Currency.PLN);
            var amountEuro = new Money(5, Currency.EURO);

            Assert.Throws<ApplicationException>(() => { var test = amountPln + amountEuro; });
        }
    }
}
