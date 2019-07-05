namespace TravelAccountant.Domain.Summaries.Wizzair
{
    public interface ICurrencyPolicy
    {
        string CurrencySymbolForPatternCheck { get; }
        string CurrencySymbolForAmount { get; }
    }
}
