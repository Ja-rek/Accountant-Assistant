using TravelAccountant.Domain.Confirmations;

namespace TravelAccountant.IntegrationTests.Domain.Confirmations
{
    internal class ConfirmationServiceGenericTest_ConfirmationPdf : ConfirmationServiceGenericTest<ConfirmationPdf>
    {
        protected override string FileExtension => "pdf";
    }
}
