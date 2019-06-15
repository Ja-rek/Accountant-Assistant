using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TravelAccountant.Domain.Summaries
{
    public class SummaryServiceComposite : ISummaryService
    {
        private readonly IDictionary<string, ISummaryService> summaryServices;

        public SummaryServiceComposite(IDictionary<string, ISummaryService> summaryServices)
        {
            this.summaryServices = summaryServices;
        }

        public IEnumerable<Summary> DrawUpSummaries(IEnumerable<string> confirmationPaths)
        {
            return this.ExecuteByFileType(confirmationPaths, 
                (service, pathByFileType) => service.DrawUpSummaries(pathByFileType));
        }

        public IEnumerable<string> FindPathsToIncorrectTemplates(IEnumerable<string> paths)
        {
            return this.ExecuteByFileType(paths, 
                (service, pathByFileType) => service.FindPathsToIncorrectTemplates(pathByFileType));
        }

        private IEnumerable<T> ExecuteByFileType<T>(IEnumerable<string> paths, 
            Func<ISummaryService, IEnumerable<string>, IEnumerable<T>> predicate)
        {
            var avalibleFileType = paths.Select(x => Path.GetExtension(x)).Distinct();
            var allItems = new List<T>();
            
            foreach (var fileType in avalibleFileType)
            {
                var pathByFileType = paths.Where(x => Path.GetExtension(x) == fileType);

                var items = predicate(this.summaryServices[fileType], pathByFileType);

                allItems.AddRange(items);
            }

            return allItems;
        }
    }
}
