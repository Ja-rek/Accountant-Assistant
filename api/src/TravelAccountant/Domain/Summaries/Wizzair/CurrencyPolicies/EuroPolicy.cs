using TravelAccountant.Domain.Moneys;

namespace TravelAccountant.Domain.Summaries.Wizzair.CurrencyPolicies
{
    public class EuroPolicy : ICurrencyPolicy
    {
        public string CurrencySymbolForPatternCheck => "EUR";
        public string CurrencySymbolForAmount => Currency.EURO;
    }
}
