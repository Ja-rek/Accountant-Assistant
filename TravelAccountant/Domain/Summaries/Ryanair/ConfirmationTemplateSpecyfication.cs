using System.Linq;
using System.Text.RegularExpressions;
using TravelAccountant.Domain.Confirmations;

namespace TravelAccountant.Domain.Summaries.Ryanair
{
    public class ConfirmationTemplateSpecyfication : IConfirmationTemplateSpecyfication<ConfirmationEmail>
    {
        private readonly ICurrencyPolicy currencyPolicy;

        public ConfirmationTemplateSpecyfication(ICurrencyPolicy currencyPolicy)
        {
            this.currencyPolicy = currencyPolicy;
        }

        public bool IsTemplateCorrect(ConfirmationEmail confirmation)
        {
            if (!confirmation.Subject.Contains("Ryanair")) return false;

            var regexs = new Regex[] 
            {
                new Regex(CofirmationTemplate.FlightNumberPattern),
                new Regex(CofirmationTemplate.AmountPattern(this.currencyPolicy.CurrencySymbolForRegex)),
                new Regex(CofirmationTemplate.PassengersPattern)
            };

            return regexs.All(regex => regex.Match(confirmation.Content).Success);
        }
    }
}
