namespace TravelAccountant.Infrastructure.Summaries
{
    public interface IFileNameStrategy
    {
        string FileNameSuffix { get; }
        string CurrencySymbol { get; }
    }
}
