using System.Collections.Generic;

namespace TravelAccountant.Domain.Confirmations
{
    public interface IConfirmationService<TConfirmation> where TConfirmation : Confirmation
    {
       IEnumerable<TConfirmation> GetConfirmations(IEnumerable<string> paths);
    }
}
