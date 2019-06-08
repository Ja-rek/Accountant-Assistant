using System.Collections.Generic;
using TravelAccountant.Domain.Confirmations;
using TravelAccountant.Domain.Summaries;

namespace TravelAccountant.Application
{
    public class SummaryApplicationService<TConfirmation> where TConfirmation : Confirmation
    {
        private readonly IConfirmationService<TConfirmation> confirmationService;
        private readonly SummariesGenerator<TConfirmation> summariesGenerator;
        private readonly ISummarySheetService summarySheetService;
        private readonly IncorrectConfirmationTemplateSpecyfication<TConfirmation> incorrectTemplateSpecyfication;

        public SummaryApplicationService(IConfirmationService<TConfirmation> confirmationService,
            SummariesGenerator<TConfirmation> summariesGenerator,
            ISummarySheetService summarySheetService,
            IncorrectConfirmationTemplateSpecyfication<TConfirmation> incorrectTemplateSpecyfication)
        {
            this.confirmationService = confirmationService;
            this.summariesGenerator = summariesGenerator;
            this.summarySheetService = summarySheetService;
            this.incorrectTemplateSpecyfication = incorrectTemplateSpecyfication;
        }

        public IEnumerable<string> GetIncorrectTemplatesFrom(IEnumerable<string> paths)
        {
            var confirmations = this.confirmationService.GetConfirmations(paths);

            return incorrectTemplateSpecyfication.FindIncorrectTemplatesOf(confirmations);
        }

        public void DrawUpTravelSummariesAsync(IEnumerable<string> confirmationPaths, string summarySheetPaths)
        {
            var confirmations = this.confirmationService.GetConfirmations(confirmationPaths);

            var summaries = this.summariesGenerator.SummariesFrom(confirmations);

            this.summarySheetService.WriteSummariesToSheet(summaries, summarySheetPaths);
        }
    }
}
