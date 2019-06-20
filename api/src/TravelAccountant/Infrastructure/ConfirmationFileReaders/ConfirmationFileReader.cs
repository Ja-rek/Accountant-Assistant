using TravelAccountant.Domain.Confirmations;
using NLog;
using Common.Utils;
using System.IO;
using static Monads.MaybeFactory;
using Monads;

namespace TravelAccountant.Infrastructure.Confirmations
{
    public abstract class ConfirmationFileReader<TConfirmation> where TConfirmation : Confirmation
    {
        protected abstract string FileType { get; }
        protected abstract TConfirmation Confirmation(string path);

        public Maybe<TConfirmation> GetConfirmation(string path)
        {
            var logger = LogManager.GetCurrentClassLogger();

            if (!File.Exists(path)) 
            {
                logger.Warn("Didn't create confirmation from {FileType} file - file not exist.");
                return Nothing;
            }

            var confirmation = Confirmation(path);

            logger.Debug($"Create confirmation:{Json.Serialize(confirmation)}");

            return confirmation;
        }
    }
}
