using System.Collections.Generic;
using TravelAccountant.Domain.Summaries;

namespace TravelAccountant.Application.Summaries
{
    public class SummaryApplicationService
    {
        private readonly ISummaryService summaryService;
        private readonly ISummarySheetService sheetService;

        public SummaryApplicationService(ISummaryService summaryService, ISummarySheetService sheetService)
        {
            this.summaryService = summaryService;
            this.sheetService = sheetService;
        }

        public IEnumerable<string> FindPathsToIncorrectTemplates(IEnumerable<string> paths)
        {
            return this.summaryService.FindPathsToIncorrectTemplates(paths);
        }

        public void FillSummarySheet(IEnumerable<string> confirmationPaths, string summarySheetPath)
        {
            var summaries = this.summaryService.DrawUpSummaries(confirmationPaths);

            this.sheetService.WriteSummariesToSheet(summaries, summarySheetPath);
        }
    }
}
