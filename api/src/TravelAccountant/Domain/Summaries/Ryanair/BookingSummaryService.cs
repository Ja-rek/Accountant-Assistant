using Monads;
using TravelAccountant.Domain.Confirmations;
using static Monads.MaybeFactory;

namespace TravelAccountant.Domain.Summaries.Ryanair
{
    public class BookingSummaryService : ISummaryFromAirlineService<ConfirmationEmail>
    {
        private readonly ICurrencyPolicy currencyPolicy;

        public BookingSummaryService(ICurrencyPolicy currencyPolicy)
        {
            this.currencyPolicy = currencyPolicy;
        }

        public Maybe<Summary> DrawUpSummaryFrom(ConfirmationEmail confirmationEmail)
        {
            var specyfication = new ConfirmationTemplateSpecyfication(this.currencyPolicy);
            if (specyfication.IsTemplateCorrect(confirmationEmail))
            {
                var rewriterService = new RewriterService(confirmationEmail);

                return new BookingSummary(confirmationEmail.Date, 
                    rewriterService.CopyTravelNumberFromConfirmation(), 
                    rewriterService.CopyAmountFromConfirmation(this.currencyPolicy), 
                    rewriterService.CopyPassengersFromConfirmation());
            }

            return Nothing;
        }
    }
}
