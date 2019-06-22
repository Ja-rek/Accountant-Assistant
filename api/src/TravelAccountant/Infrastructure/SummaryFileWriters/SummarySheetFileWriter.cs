using System.Collections.Generic;
using System.Linq;
using Common.Utils;
using NLog;
using TravelAccountant.Domain.Summaries;
using static Suckless.Asserts.Assertions;

namespace TravelAccountant.Infrastructure.Summaries
{
    public class SummarySheetFileWriter : ISummarySheetService
    {
        private readonly IFileNameStrategy fileNameStrategy;
        private readonly Logger logger;

        public SummarySheetFileWriter(IFileNameStrategy fileNameStrategy)
        {
            this.logger = LogManager.GetCurrentClassLogger();
            this.fileNameStrategy = fileNameStrategy;
        }

        public void WriteSummariesToSheet(IEnumerable<Summary> summaries, string path)
        {
            var summariesByCurrency = summaries
                .Where(summary => summary.Amount.Currency == this.fileNameStrategy.CurrencySymbol);

            if (summariesByCurrency.Any())
            {
                var summariesByCurrencyPersitence = summariesByCurrency
                    .Select(summary => new SummaryExelPersistence(summary));

                Save(path, summariesByCurrencyPersitence);
            }
        }

        private void Save(string path, IEnumerable<SummaryExelPersistence> persistences)
        {
            logger.Debug($"Created persistence object: {Json.Serialize(persistences)}");

            var mapper = SummaryMapping.Mapper(this.fileNameStrategy.CurrencySymbol);

            var position = path.Count() -5;
            var concreteFilePath = path.Insert(position, this.fileNameStrategy.FileNameSuffix);

            mapper.Save(concreteFilePath, persistences, overwrite: true, xlsx: true);

            logger.Info($"Saved at: {concreteFilePath}");
        }
    }
}
