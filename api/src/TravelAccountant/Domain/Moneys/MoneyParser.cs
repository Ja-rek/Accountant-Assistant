using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using Common.Utils;
using Monads;
using NLog;
using static Monads.MaybeFactory;

namespace TravelAccountant.Domain.Moneys
{
    internal static class MoneyValueParser
    {
        public static Maybe<decimal> Parse(string amount)
        {
            var mached = Regex.Match(amount, @"[0-9\-,.\s]{2,}");

            var log = LogManager.GetCurrentClassLogger();

            log.Debug($"Try parse: '{amount}'.");

            if (mached.Success & mached.Value.Any(char.IsDigit))
            {
                NumberFormatInfo formatIfo = new NumberFormatInfo();
                formatIfo.NegativeSign = "-";
                formatIfo.CurrencyDecimalSeparator = ".";

                var value = decimal.Parse(CorrectCharacters(mached.Value), NumberStyles.Currency, formatIfo);

                log.Debug($"Reuslt of parsing: '{amount}'.");

                return value;
            }

            log.Debug($"Did not parsed.");

            return Nothing;
        }

        private static string CorrectCharacters(string amountValue)
        {
            if (amountValue.ContainsOneOf(",", "."))
            {
                return GetLeftPart(amountValue) + "." + GetRightPart(amountValue);
            }

            return amountValue;
        }

        private static string GetLeftPart(string amountValue)
        {
            var leftPart = amountValue
                .ReplaceAllTo(string.Empty, " ", ",", ".");

            return leftPart
                .Remove(leftPart.Count() -2);
        }

        private static string GetRightPart(string amountValue)
        {
            var rightPart = amountValue
                    .Replace(" ", string.Empty)
                    .Replace(",", ".");

            return rightPart
                .Substring(rightPart.Count() - 2, 2);
        }

        private static bool ContainsOneOf(this string source, params string[] values)
        {
            return values.Any(source.Contains);
        }
    }
}
