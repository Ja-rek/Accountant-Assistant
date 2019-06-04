using System.IO;
using TravelAccountant.Domain.Confirmations;
using Common.Utils;
using MimeKit;
using System.Collections.Generic;
using System.Linq;
using static Suckless.Asserts.Assertions;
using Monads.Extensions.Linq;

namespace TravelAccountant.Infrastructure.Confirmations
{
    public class ConfirmationEmlFileReader : ConfirmationFileReader<ConfirmationEmail>, IConfirmationService<ConfirmationEmail>
    {
        public IEnumerable<ConfirmationEmail> GetConfirmations(IEnumerable<string> paths)
        {
            return paths.Select(base.GetConfirmation).Values();
        }

        protected override string FileType => "eml";

        protected override ConfirmationEmail Confirmation(string path)
        {
            Assert(path).EmlFile();

            var stream = File.OpenRead(path);
            var message = new MimeParser(stream, MimeFormat.Default).ParseMessage();

            return new ConfirmationEmail(path, message.Subject, message.Date.Date, message.Body.ToString());
        }
    }
}
