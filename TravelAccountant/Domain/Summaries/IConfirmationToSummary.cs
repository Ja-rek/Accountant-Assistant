using Monads;
using TravelAccountant.Domain.Confirmations;

namespace TravelAccountant.Domain.Summaries
{
    public interface IConfirmationToSummary<TConfirmation> where TConfirmation : Confirmation
    {
        Maybe<Summary> DrawUpSummaryFrom(TConfirmation confirmation);
    }
}
