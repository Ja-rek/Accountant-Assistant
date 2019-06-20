using System.Collections.Generic;
using Monads.Extensions.Linq;
using System.Linq;
using System.Threading.Tasks;
using TravelAccountant.Domain.Confirmations;

namespace TravelAccountant.Domain.Summaries
{
    public class SummaryService<TConfirmation> : ISummaryService
        where TConfirmation : Confirmation
    {
        private readonly IEnumerable<IConfirmationToSummary<TConfirmation>> confirmationToSumaryService;
        private readonly IncorrectConfirmationTemplateSpecyfication<TConfirmation> specyfication;
        private readonly IConfirmationService<TConfirmation> confirmationService;

        public SummaryService(IEnumerable<IConfirmationToSummary<TConfirmation>> confirmationToSumaryService,
            IncorrectConfirmationTemplateSpecyfication<TConfirmation> specyfication,
            IConfirmationService<TConfirmation> confirmationService)
        {
            this.confirmationToSumaryService = confirmationToSumaryService;
            this.specyfication = specyfication;
            this.confirmationService = confirmationService;
        }

        public IEnumerable<Summary> DrawUpSummaries(IEnumerable<string> confirmationPaths)
        {
            var confirmations = this.confirmationService.GetConfirmations(confirmationPaths);

            return this.SummariesFrom(confirmations);
        }

        public IEnumerable<string> FindPathsToIncorrectTemplates(IEnumerable<string> paths)
        {
            var confirmations = this.confirmationService.GetConfirmations(paths);

            return this.specyfication.FindIncorrectTemplates(confirmations);
        }


        private IEnumerable<Summary> SummariesFrom(IEnumerable<TConfirmation> confirmations)
        {
            var allSummaries = new List<Summary>();

            Parallel.ForEach(confirmations, confirmation => 
            {
                var summaries = confirmationToSumaryService
                    .Select(service => service.DrawUpSummaryFrom(confirmation)).Values();

                allSummaries.AddRange(summaries);
            });

            return allSummaries;
        }
    }
}
