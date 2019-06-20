namespace TravelAccountant.Domain.Summaries.Ryanair
{
    public class CofirmationTemplate
    {
        public static string AmountPattern(string currencyToSearch)
        {
            return @"<strong>\d+\.\d+\s{1}"+currencyToSearch+"<\\/strong>";
        }

        public const string FlightNumberPattern = "Roboto';font-weight:bold;line-height:14px;white-space:nowrap;\">\\w+<\\/div><\\/td>";
        public const string PassengersPattern = @">\p{Lu}{1}\p{Ll}+(\s{1}\p{Lu}{3,}(-\p{Lu}{3,})?)+<";
    }
}
