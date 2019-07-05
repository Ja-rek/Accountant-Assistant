using System.Collections.Generic;
using System.Linq;
using TravelAccountant.Domain.Confirmations;

namespace TravelAccountant.Domain.Summaries.Wizzair
{
    public class ConfirmationTemplateSpecyfication : IConfirmationTemplateSpecyfication<ConfirmationPdf>
    {
        private readonly ICurrencyPolicy currencyPolicy;

        public ConfirmationTemplateSpecyfication(ICurrencyPolicy currencyPolicy)
        {
            this.currencyPolicy = currencyPolicy;
        }

        public bool IsTemplateCorrect(ConfirmationPdf confirmationPdf)
        {
            var confirmationContent = ConfirmationPdfUtil.ToEnumerable(confirmationPdf);

            if (!confirmationContent.Take(25).Any(x => x.Contains("Wizz"))) return false;

            var patterns  = new string[] 
            {
                ConfirmationTemplate.AmountPattern,
                ConfirmationTemplate.BookIdPattern,
                ConfirmationTemplate.IdNumberIdPattern,
                ConfirmationTemplate.DatePattern
            };

            return confirmationContent.Contains(this.currencyPolicy.CurrencySymbolForPatternCheck) 
                && patterns.All(pattern => Match(confirmationContent, pattern));
        }

        private bool Match(IEnumerable<string> confirmationContent, string pattern)
        {
            return confirmationContent.Any(x => x.Contains(pattern));
        }
    }
}
