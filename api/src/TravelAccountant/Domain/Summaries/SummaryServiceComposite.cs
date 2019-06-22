using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Common.Utils;
using NLog;

namespace TravelAccountant.Domain.Summaries
{
    public class SummaryServiceComposite : ISummaryService
    {
        private readonly IReadOnlyDictionary<string, ISummaryService> summaryServices;
        private readonly Logger logger;

        public SummaryServiceComposite(IReadOnlyDictionary<string, ISummaryService> summaryServices)
        {
            this.summaryServices = summaryServices;
            this.logger = LogManager.GetCurrentClassLogger();
        }

        public IEnumerable<Summary> DrawUpSummaries(IEnumerable<string> confirmationPaths)
        {
            var result = this.ExecuteByFileType(confirmationPaths, 
                (service, pathByFileType) => service.DrawUpSummaries(pathByFileType));

            this.logger.Debug("Drawn up summaries: " + Json.Serialize(result));

            return result;
        }

        public IEnumerable<string> FindPathsToIncorrectTemplates(IEnumerable<string> paths)
        {
            var result = this.ExecuteByFileType(paths, 
                (service, pathByFileType) => service.FindPathsToIncorrectTemplates(pathByFileType));

            this.logger.Info("Found Paths to incorrect templates: " + Json.Serialize(result));

            return result;
        }

        private IEnumerable<T> ExecuteByFileType<T>(IEnumerable<string> paths, 
            Func<ISummaryService, IEnumerable<string>, IEnumerable<T>> predicate)
        {

            var avalibleFileType = paths.Select(x => Path.GetExtension(x)).Distinct();
            var allItems = new List<T>();

            this.logger.Debug("Avalible file type: " + Json.Serialize(avalibleFileType));
            
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
