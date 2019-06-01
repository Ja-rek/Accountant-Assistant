using TravelAccountant.Domain.Confirmations;

namespace TravelAccountant.Domain.Summaries
{
    public interface IConfirmationTemplateSpecyfication<TConfirmation> where TConfirmation : Confirmation
    {
        bool IsTemplateCorrect(TConfirmation confirmation);
    }
}
