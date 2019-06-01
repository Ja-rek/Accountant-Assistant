using TravelAccountant.Domain.Moneys;
using Monads.Extensions.Unsafe;
using NUnit.Framework;

namespace TravelAccountant.UnitTests.Domain.Moneys
{
    internal partial class MoneyFactoryTest
    {
        [Test]
        public void EuroFrom_WhenAmountIsShort_ThenCanParse()
        {
            var money = MoneyFactory.EuroFrom("5.53 USD");

            Assert.AreEqual(5.53m, money.Value().Value);
            Assert.AreEqual(Currency.EURO, money.Value().Currency);
        }

        [Test]
        public void EuroFrom_WhenAmountHasMinus_ThenCanParse()
        {
            var money = MoneyFactory.EuroFrom("- 1,545.53 USD");

            Assert.AreEqual(-1545.53m, money.Value().Value);
            Assert.AreEqual(Currency.EURO, money.Value().Currency);
        }

        [Test]
        public void EuroFrom_WhenGroupSeparatorIsComa_ThenCanParse()
        {
            var money = MoneyFactory.EuroFrom("1,545.53 USD");

            Assert.AreEqual(1545.53m, money.Value().Value);
            Assert.AreEqual(Currency.EURO, money.Value().Currency);
        }

        [Test]
        public void EuroFrom_WhenGroupSeparatorIsDot_ThenCanParse()
        {
            var money = MoneyFactory.EuroFrom("1.545.53 USD");

            Assert.AreEqual(1545.53m, money.Value().Value);
            Assert.AreEqual(Currency.EURO, money.Value().Currency);
        }

        [Test]
        public void EuroFrom_WhenGroupSeparatorIsWhiteSpace_ThenCanParse()
        {
            var money = MoneyFactory.EuroFrom("1 545.53 USD");

            Assert.AreEqual(1545.53m, money.Value().Value);
            Assert.AreEqual(Currency.EURO, money.Value().Currency);
        }

        [Test]
        public void EuroFrom_WhenDecimalSeparatorIsComma_ThenCanParse()
        {
            var money = MoneyFactory.EuroFrom("1 545,53 USD");

            Assert.AreEqual(1545.53m, money.Value().Value);
            Assert.AreEqual(Currency.EURO, money.Value().Currency);
        }
        
        [Test]
        public void EuroFrom_WhenCurrencyIsDifferent_ThenCanParse()
        {
            var money = MoneyFactory.EuroFrom("zł euro1 545,53zł USD");

            Assert.AreEqual(1545.53m, money.Value().Value);
            Assert.AreEqual(Currency.EURO, money.Value().Currency);
        }

        [Test]
        public void EuroFrom_WhenCurrencyFormatIsStrang_ThenCanParse()
        {
            var money = MoneyFactory.EuroFrom("zł,sdf.sdf l euro1 5.,4.5,.53zł sdfsdf USD");

            Assert.AreEqual(1545.53m, money.Value().Value);
            Assert.AreEqual(Currency.EURO, money.Value().Currency);
        }

        [Test]
        public void EuroFrom_WhenCurrencyFormatIsIncorrect_ThenCanNotParse()
        {
            var money = MoneyFactory.EuroFrom(".,sdf4.5s,.5s3zł");

            Assert.False(money.HasValue());
        }

        [Test]
        public void EuroFrom_WhenCurrencyContainOnlyCents_ThenCanNotParse()
        {
            var money = MoneyFactory.EuroFrom("50 cents");

            Assert.AreEqual(50m, money.Value().Value);
            Assert.AreEqual(Currency.EURO, money.Value().Currency);
        }
    }
}
