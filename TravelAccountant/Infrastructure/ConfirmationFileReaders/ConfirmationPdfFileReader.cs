using XpdfNet;
using System.Collections.Generic;
using System.Linq;
using TravelAccountant.Domain.Confirmations;
using NLog;
using Common.Utils;
using System.IO;
using static Suckless.Asserts.Assertions;

namespace TravelAccountant.Infrastructure.Confirmations
{
    public class ConfirmationPdfFileReader : IConfirmationService<ConfirmationPdf> 
    {
        public IEnumerable<ConfirmationPdf> GetConfirmations(IEnumerable<string> paths)
        {
            return paths.Select(this.GetConfirmation);
        }

        private ConfirmationPdf GetConfirmation(string path)
        {
            Assert(path).PdfFile();

            var logger = LogManager.GetCurrentClassLogger();

            logger.Debug($"Try load confirmation from pdf file: '{path}'.");

            if (!File.Exists(path)) throw new FileNotFoundException("Could not found file.");

            var text = new XpdfHelper().ToText(path);

            var confirmation = new ConfirmationPdf(path, text);

            logger.Debug($"Create confirmation:{Json.Serialize(confirmation)}");

            return confirmation;
        }

        private static IEnumerable<string> ToCollection(string content)
        {
            return content
                .Replace("\r", string.Empty)
                .Replace("\n", " ")
                .Split(' ')
                .Where(x => x != string.Empty);
        }
    }
}
