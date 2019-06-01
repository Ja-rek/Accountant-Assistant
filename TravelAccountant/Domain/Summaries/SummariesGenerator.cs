using System.Collections.Generic;
using Monads.Extensions.Linq;
using System.Linq;
using System.Threading.Tasks;
using TravelAccountant.Domain.Confirmations;

namespace TravelAccountant.Domain.Summaries
{
    public class SummariesGenerator<TConfirmation> where TConfirmation : Confirmation
    {
        private readonly IEnumerable<ISummaryService<TConfirmation>> summaryServices;

        public SummariesGenerator(IEnumerable<ISummaryService<TConfirmation>> summaryServices)
        {
            this.summaryServices = summaryServices;
        }

        public async Task<IEnumerable<Summary>> SummariesFrom(IEnumerable<TConfirmation> confirmations)
        {
            var allSummaries = new List<Summary>();

            return await Task.Run(() => 
            {
                foreach (var confirmation in confirmations)
                {
                    var summaries = summaryServices
                        .Select(service => service.DrawUpSummaryFrom(confirmation)).Values();

                    allSummaries.AddRange(summaries);
                };

                return allSummaries;
            });
        }
    }
}
