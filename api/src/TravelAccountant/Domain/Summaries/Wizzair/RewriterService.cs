using System.Collections.Generic;
using System.Linq;
using TravelAccountant.Domain.Moneys;
using NLog;
using TravelAccountant.Domain.Confirmations;
using Monads.Extensions.Unsafe;
using static Suckless.Asserts.Assertions;
using System;

namespace TravelAccountant.Domain.Summaries.Wizzair
{
    public class RewriterService
    {
        private readonly IEnumerable<string> confirmationContent;
        private readonly Logger logger;

        public RewriterService(ConfirmationPdf confirmationPdf)
        {
            AssertNotNull(confirmationPdf);

            this.confirmationContent = ConfirmationPdfUtil.ToEnumerable(confirmationPdf);
            this.logger = LogManager.GetCurrentClassLogger();
        }

        public Money CopyAmountFromConfirmation(ICurrencyPolicy policy)
        {
            var value = this.Match(4, ConfirmationTemplate.AmountPattern) ;

            var amount = MoneyFactory.Money(value, policy.CurrencySymbolForAmount);

            if (!amount.HasValue()) throw new ApplicationException("Amount not exist");

            var amountValue = amount.Value();

            LogMachedValue(amountValue.Value + amountValue.Currency);

            return amountValue;
        }

        public DateTime CopyDateFromConfirmation()
        {
            var date = this.Match(1, ConfirmationTemplate.DatePattern); 

            LogMachedValue(date);

            return DateTime.Parse(date); 
        }

        public string CopyBookingIdFromConfirmation()
        {
            var date = this.Match(1, ConfirmationTemplate.BookIdPattern); 

            LogMachedValue(date);

            return date; 
        }

        public string CopyInvocieNumberFromConfirmation()
        {
            var date = this.Match(1, ConfirmationTemplate.IdNumberIdPattern); 

            LogMachedValue(date);

            return date; 
        }

        private void LogMachedValue(string position)
        {
            this.logger.Debug("Matched value : " + position);
        }

        private string Match(int skip, string patterns)
        {
            var index = this.confirmationContent.ToList()
                .FindIndex(x => x.Replace(" ", string.Empty) == patterns);

            var exception = new ApplicationException("Not found");

            if (index == -1) throw exception;

            return confirmationContent.ElementAt(index + skip) ?? throw exception;
        }
    }
}
