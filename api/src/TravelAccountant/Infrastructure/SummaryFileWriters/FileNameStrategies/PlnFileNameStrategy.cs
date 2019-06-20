using TravelAccountant.Domain.Moneys;

namespace TravelAccountant.Infrastructure.Summaries.FileNameStrategies
{
    public class PlnFileNameStrategy : IFileNameStrategy
    {
        public PlnFileNameStrategy()
        {
            FileNameSuffix = "Pln";
            CurrencySymbol = Currency.PLN;
        }

        public string FileNameSuffix { get; }
        public string CurrencySymbol { get; }
    }
}
