using System.Collections.Generic;
using System.Linq;
using TravelAccountant.Domain.Confirmations;

namespace TravelAccountant.Domain.Summaries
{
    public class IncorrectConfirmationTemplateSpecyfication<TConfirmation> where TConfirmation : Confirmation
    {
        private readonly IEnumerable<IConfirmationTemplateSpecyfication<TConfirmation>> confirmationTemplateSpecyfications;

        public IncorrectConfirmationTemplateSpecyfication(
            IEnumerable<IConfirmationTemplateSpecyfication<TConfirmation>> confirmationTemplateSpecyfications)
        {
            this.confirmationTemplateSpecyfications = confirmationTemplateSpecyfications;
        }

        public IEnumerable<string> FindIncorrectTemplateOf(IEnumerable<TConfirmation> confirmations)
        {
            return confirmations.AsParallel()
                .Where(c => this.confirmationTemplateSpecyfications.Any(x => x.IsTemplateCorrect(c)))
                .Select(c => c.FilePath);
        }
    }
}
