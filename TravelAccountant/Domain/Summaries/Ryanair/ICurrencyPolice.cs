namespace TravelAccountant.Domain.Summaries.Ryanair
{
    public interface ICurrencyPolicy
    {
        string CurrencySymbolForRegex { get; }
        string CurrencySymbolForAmount { get; }
    }
}
