using static Suckless.Asserts.Assertions;
using Common.Utils;

namespace TravelAccountant.Domain.Confirmations
{
    public class ConfirmationPdf : Confirmation
    {
        public ConfirmationPdf(string filePath, string content) : base(filePath, content)
        {
            Assert(filePath).PdfFile();
        }
    }
}
