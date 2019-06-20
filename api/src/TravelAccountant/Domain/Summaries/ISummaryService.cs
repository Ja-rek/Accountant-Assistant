using System.Collections.Generic;

namespace TravelAccountant.Domain.Summaries
{
    public interface ISummaryService
    {
        IEnumerable<string> FindPathsToIncorrectTemplates(IEnumerable<string> paths);
        IEnumerable<Summary> DrawUpSummaries(IEnumerable<string> confirmationPaths);
    }
}
