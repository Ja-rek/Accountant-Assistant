using TravelAccountant.Domain.Moneys;
using Monads.Extensions.Unsafe;
using NUnit.Framework;

namespace TravelAccountant.UnitTests.Domain.Moneys
{
    internal partial class MoneyFactoryTest
    {
        [Test]
        public void PlnFrom_WhenAmountIsShort_ThenCanParse()
        {
            var money = MoneyFactory.PlnFrom("5.53 USD");

            Assert.AreEqual(5.53m, money.Value().Value);
            Assert.AreEqual(Currency.PLN, money.Value().Currency);
        }

        [Test]
        public void PlnFrom_WhenAmountHasMinus_ThenCanParse()
        {
            var money = MoneyFactory.PlnFrom("- 1,545.53 USD");

            Assert.AreEqual(-1545.53m, money.Value().Value);
            Assert.AreEqual(Currency.PLN, money.Value().Currency);
        }

        [Test]
        public void PlnFrom_WhenGroupSeparatorIsComa_ThenCanParse()
        {
            var money = MoneyFactory.PlnFrom("1,545.53 USD");

            Assert.AreEqual(1545.53m, money.Value().Value);
            Assert.AreEqual(Currency.PLN, money.Value().Currency);
        }

        [Test]
        public void PlnFrom_WhenGroupSeparatorIsDot_ThenCanParse()
        {
            var money = MoneyFactory.PlnFrom("1.545.53 USD");

            Assert.AreEqual(1545.53m, money.Value().Value);
            Assert.AreEqual(Currency.PLN, money.Value().Currency);
        }

        [Test]
        public void PlnFrom_WhenGroupSeparatorIsWhiteSpace_ThenCanParse()
        {
            var money = MoneyFactory.PlnFrom("1 545.53 USD");

            Assert.AreEqual(1545.53m, money.Value().Value);
            Assert.AreEqual(Currency.PLN, money.Value().Currency);
        }

        [Test]
        public void PlnFrom_WhenDecimalSeparatorIsComma_ThenCanParse()
        {
            var money = MoneyFactory.PlnFrom("1 545,53 USD");

            Assert.AreEqual(1545.53m, money.Value().Value);
            Assert.AreEqual(Currency.PLN, money.Value().Currency);
        }
        
        [Test]
        public void PlnFrom_WhenCurrencyIsDifferent_ThenCanParse()
        {
            var money = MoneyFactory.PlnFrom("zł euro1 545,53zł USD");

            Assert.AreEqual(1545.53m, money.Value().Value);
            Assert.AreEqual(Currency.PLN, money.Value().Currency);
        }

        [Test]
        public void PlnFrom_WhenCurrencyFormatIsStrang_ThenCanParse()
        {
            var money = MoneyFactory.PlnFrom("zł,sdf.sdf l euro1 5.,4.5,.53zł sdfsdf USD");

            Assert.AreEqual(1545.53m, money.Value().Value);
            Assert.AreEqual(Currency.PLN, money.Value().Currency);
        }

        [Test]
        public void PlnFrom_WhenCurrencyFormatIsIncorrect_ThenCanNotParse()
        {
            var money = MoneyFactory.PlnFrom(".,sdf4.5s,.5s3zł");

            Assert.False(money.HasValue());
        }

        [Test]
        public void PlnFrom_WhenCurrencyContainOnlyCents_ThenCanNotParse()
        {
            var money = MoneyFactory.PlnFrom("50 cents");

            Assert.AreEqual(50m, money.Value().Value);
            Assert.AreEqual(Currency.PLN, money.Value().Currency);
        }
    }
}
