using System.Collections.Generic;
using System.Linq;
using Monads.Extensions.Linq;
using TravelAccountant.Domain.Moneys;
using Common.Utils;
using NLog;
using TravelAccountant.Domain.Confirmations;
using System.Text.RegularExpressions;
using Monads.Extensions.Unsafe;
using static Suckless.Asserts.Assertions;
using System.Collections.ObjectModel;
using System;

namespace TravelAccountant.Domain.Summaries.Ryanair
{
    public class RewriterService
    {
        private readonly ConfirmationEmail confirmationEmail;
        private readonly Logger logger;

        public RewriterService(ConfirmationEmail confirmationEmail)
        {
            AssertNotNull(confirmationEmail);

            this.confirmationEmail = confirmationEmail;
            this.logger = LogManager.GetCurrentClassLogger();
        }

        public Money CopyAmountFromConfirmation(ICurrencyPolicy policy)
        {
            var amountValue = GetValueByRegexs(
                patternToMatchPosition: CofirmationTemplate.AmountPattern(policy.CurrencySymbolForRegex),
                patternToMatchValue:@"\d+\.\d+"); 

            var amount = MoneyFactory.Money(amountValue, policy.CurrencySymbolForAmount).Value();

            LogMachedValue(amount.ToString());

            return amount;
        }

        public string CopyTravelNumberFromConfirmation()
        {
            var flightNumber = GetValueByRegexs(patternToMatchPosition: CofirmationTemplate.FlightNumberPattern,
                patternToMatchValue: @">\w+<").ReplaceAllTo(string.Empty, "<", ">"); 

            LogMachedValue(flightNumber);

            return flightNumber; 
        }

        public IEnumerable<string> CopyPassengersFromConfirmation()
        {
            var passengersPositions = new Regex(CofirmationTemplate.PassengersPattern)
                .Matches(confirmationEmail.Content)
                .Cast<Match>()
                .Select(m => m.Value);

            if (!passengersPositions.Any()) throw new ApplicationException("No passengers positions.");

            var passangers = new Collection<string>();

            foreach (var passengersPosition in passengersPositions)
            {
                LogMachedPossition(passengersPosition);

                var matchPassengerValueByRegex = new Regex(@"(\s{1}\p{Lu}{3,}(-\p{Lu}{3,})?)+")
                    .Match(passengersPosition);

                Assert(matchPassengerValueByRegex).Success();

                var passanger = matchPassengerValueByRegex.Value.Substring(1);

                LogMachedValue(passanger);

                passangers.Add(passanger);
            }

            return passangers.Where(p => p != string.Empty)
                .Distinct();
        }

        private string GetValueByRegexs(string patternToMatchPosition, string patternToMatchValue)
        {
            var matchPositionByRegex = new Regex(patternToMatchPosition).Match(this.confirmationEmail.Content);

            Assert(matchPositionByRegex).Success();

            LogMachedPossition(matchPositionByRegex.Value);

            var mathcValueByRegex = new Regex(patternToMatchValue).Match(matchPositionByRegex.Value);

            Assert(mathcValueByRegex).Success();

            return mathcValueByRegex.Value;
        }

        private void LogMachedPossition(string position)
        {
            this.logger.Debug("Matched possition : " + position);
        }

        private void LogMachedValue(string position)
        {
            this.logger.Debug("Matched value : " + position);
        }
    }
}
