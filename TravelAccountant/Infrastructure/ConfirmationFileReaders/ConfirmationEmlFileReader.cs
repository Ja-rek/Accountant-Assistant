using System.IO;
using TravelAccountant.Domain.Confirmations;
using Common.Utils;
using MimeKit;
using NLog;
using System.Collections.Generic;
using System.Linq;
using static Suckless.Asserts.Assertions;

namespace TravelAccountant.Infrastructure.Confirmations 
{
    public class ConfirmationEmlFileReader : IConfirmationService<ConfirmationEmail>
    {
        public IEnumerable<ConfirmationEmail> GetConfirmations(IEnumerable<string> paths)
        {
            return paths.Select(this.GetConfirmation);
        }

        private ConfirmationEmail GetConfirmation(string path)
        {
            Assert(path).EmlFile();

            var logger = LogManager.GetCurrentClassLogger();

            logger.Debug($"Try load confirmation from eml file: '{path}'.");

            if (!File.Exists(path)) throw new FileNotFoundException("Could not found file.");

            var stream = File.OpenRead(path);
            var message = new MimeParser(stream, MimeFormat.Default)
                .ParseMessage();

            var confirmation = new ConfirmationEmail(path, 
                message.Subject, 
                message.Date.Date, 
                message.Body.ToString());

            logger.Debug($"Create confirmation:{Json.Serialize(confirmation)}");

            return confirmation;
        }

    }
}
