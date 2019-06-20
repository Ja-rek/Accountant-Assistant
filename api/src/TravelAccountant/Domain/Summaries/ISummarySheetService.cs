using System.Collections.Generic;

namespace TravelAccountant.Domain.Summaries
{
    public interface ISummarySheetService
    {
        void WriteSummariesToSheet(IEnumerable<Summary> summaries, string path);
    }
}
