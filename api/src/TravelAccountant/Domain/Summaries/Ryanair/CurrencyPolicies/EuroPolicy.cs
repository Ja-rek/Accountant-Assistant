using TravelAccountant.Domain.Moneys;

namespace TravelAccountant.Domain.Summaries.Ryanair.CurrencyPolicies
{
    public class EuroPolicy : ICurrencyPolicy
    {
        public string CurrencySymbolForRegex => "EUR";
        public string CurrencySymbolForAmount => Currency.EURO;
    }
}
