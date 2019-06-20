using Monads;

namespace TravelAccountant.Domain.Moneys
{
    public class MoneyFactory
    {
        public static Maybe<Money> Money(string amount, string currency)
        {
            return Builder(amount, currency);
        }

        public static Maybe<Money> EuroFrom(string amount)
        {
            return Builder(amount, Currency.EURO);
        }

        public static Maybe<Money> PlnFrom(string amount)
        {
            return Builder(amount, Currency.PLN);
        }

        private static Maybe<Money> Builder(string amount, string currency)
        {
            return MoneyValueParser
                .Parse(amount)
                .Map(x => new Money(x, currency));
        }
    }
}
