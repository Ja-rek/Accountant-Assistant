using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoFixture;
using NUnit.Framework;
using TravelAccountant.Domain.Moneys;
using TravelAccountant.Domain.Summaries;
using TravelAccountant.Domain.Summaries.Ryanair;

namespace TravelAccountant.IntegrationTests.Domain.Summaries
{
    internal class SummarySheetServiceTest
    {
        const string DIRECTORY = "/home/jk/projects/AccountantAssistant/TravelAccountant."
            + "IntegrationTests/Domain/Summaries/Files/";

        const string fileEuro = DIRECTORY+ "TestEuro.xlsx";
        const string filePln = DIRECTORY+ "TestPln.xlsx";

        [TearDown]
        public void TearDown()
        {
            if (File.Exists(fileEuro)) File.Delete(fileEuro);
            if (File.Exists(filePln)) File.Delete(filePln);
        }

        [Test]
        public void WriteSummariesToSheet_WhenSaveingSummariesTofile_ThenCreateCorrectFilesOnDisk()
        {
            SummaryShetService().WriteSummariesToSheet(Summaries(), DIRECTORY + "Test.xlsx");;

            Assert.True(File.Exists(DIRECTORY+ "TestEuro.xlsx"));
            Assert.True(File.Exists(DIRECTORY+ "TestPln.xlsx"));
        }

        private IEnumerable<BookingSummary> Summaries()
        {
            var summaries = SummariesByCurrency(Currency.EURO);
            summaries.AddRange(SummariesByCurrency(Currency.PLN)); 

            return summaries;
        }

        private List<BookingSummary> SummariesByCurrency(string currency)
        {
            var fixture = new Fixture();
            fixture.Register(() => new Money(15, currency));

            return fixture.CreateMany<BookingSummary>(5).ToList();
        }

        private ISummarySheetService SummaryShetService()
        {
            return ServiceLocator.Resolve<ISummarySheetService>();
        }
    }
}
