using TravelAccountant.Domain.Moneys;

namespace TravelAccountant.Domain.Summaries.Wizzair.CurrencyPolicies
{
    public class PlnPolicy : ICurrencyPolicy
    {
        public string CurrencySymbolForPatternCheck => "PLN";
        public string CurrencySymbolForAmount => Currency.PLN;

    }
}
