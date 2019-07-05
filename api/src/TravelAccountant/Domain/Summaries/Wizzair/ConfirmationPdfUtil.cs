using System.Collections.Generic;
using System.Linq;
using TravelAccountant.Domain.Confirmations;

namespace TravelAccountant.Domain.Summaries.Wizzair
{
    public class ConfirmationPdfUtil
    {
        public static IEnumerable<string> ToEnumerable(ConfirmationPdf confirmationPdf)
        {
            return confirmationPdf.Content
                .Replace("\r", string.Empty)
                .Replace("\n", " ")
                .Split(' ')
                .Where(x => x != string.Empty);
        }
    }
}
