using System.Collections.Generic;
using TravelAccountant.Domain.Summaries;

namespace TravelAccountant.Infrastructure.Summaries
{
    public class SummarySheetFileWriterComposite : ISummarySheetService
    {
        private readonly IEnumerable<ISummarySheetService> summarySheetServices;

        public SummarySheetFileWriterComposite(IEnumerable<ISummarySheetService> summarySheetServices)
        {
            this.summarySheetServices = summarySheetServices;
        }

        public void WriteSummariesToSheet(IEnumerable<Summary> summaries, string path)
        {
            WriteToFilesWithNameByCurrency(summaries, path);
        }

        private void WriteToFilesWithNameByCurrency(IEnumerable<Summary> summaries, string path)
        {
            foreach (var summarySheetService in this.summarySheetServices)
            {
                summarySheetService.WriteSummariesToSheet(summaries, path);
            }
        }
    }
}
