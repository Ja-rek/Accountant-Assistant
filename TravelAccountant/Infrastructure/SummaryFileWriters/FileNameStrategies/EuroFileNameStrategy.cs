using TravelAccountant.Domain.Moneys;

namespace TravelAccountant.Infrastructure.Summaries.FileNameStrategies
{
    public class EuroFileNameStrategy : IFileNameStrategy
    {
        public EuroFileNameStrategy()
        {
            FileNameSuffix = "Euro";
            CurrencySymbol = Currency.EURO;
        }

        public string FileNameSuffix { get; }
        public string CurrencySymbol { get; }
    }
}
