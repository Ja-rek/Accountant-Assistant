using XpdfNet;
using System.Collections.Generic;
using System.Linq;
using TravelAccountant.Domain.Confirmations;
using Common.Utils;
using static Suckless.Asserts.Assertions;
using Monads.Extensions.Linq;

namespace TravelAccountant.Infrastructure.Confirmations
{
    public class ConfirmationPdfFileReader : ConfirmationFileReader<ConfirmationPdf>, IConfirmationService<ConfirmationPdf> 
    {
        public IEnumerable<ConfirmationPdf> GetConfirmations(IEnumerable<string> paths)
        {
            return paths.Select(base.GetConfirmation).Values();
        }

        protected override string FileType => "pdf";

        protected override ConfirmationPdf Confirmation(string path)
        {
            Assert(path).PdfFile();

            var text = new XpdfHelper().ToText(path);

            return new ConfirmationPdf(path, text);
        }
    }
}
