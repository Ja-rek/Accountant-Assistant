using Monads;
using TravelAccountant.Domain.Confirmations;
using static Monads.MaybeFactory;

namespace TravelAccountant.Domain.Summaries.Wizzair
{
    public class InvoiceSummaryService : ISummaryFromAirlineService<ConfirmationPdf>
    {
        private readonly ICurrencyPolicy currencyPolicy;

        public InvoiceSummaryService(ICurrencyPolicy currencyPolicy)
        {
            this.currencyPolicy = currencyPolicy;
        }

        public Maybe<Summary> DrawUpSummaryFrom(ConfirmationPdf confirmationPdf)
        {
            var specyfication = new ConfirmationTemplateSpecyfication(this.currencyPolicy);
            if (specyfication.IsTemplateCorrect(confirmationPdf))
            {
                var rewriterService = new RewriterService(confirmationPdf);

                return new InvoiceSummary(rewriterService.CopyDateFromConfirmation(),
                    rewriterService.CopyInvocieNumberFromConfirmation(),
                    rewriterService.CopyAmountFromConfirmation(this.currencyPolicy),
                    rewriterService.CopyBookingIdFromConfirmation());
            }

            return Nothing;
        }
    }
}
