using TravelAccountant.Domain.Moneys;

namespace TravelAccountant.Domain.Summaries.Ryanair.ConfirmationTemplate.CurrencyPolicies
{
    public class PlnPolicy : ICurrencyPolicy
    {
        public string CurrencySymbolForRegex => "PLN";
        public string CurrencySymbolForAmount => Currency.PLN;

    }
}
