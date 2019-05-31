using TravelAccountant.Domain.Confirmations;

namespace TravelAccountant.IntegrationTests.Domain.Confirmations
{
    internal class ConfirmationServiceGenericTest_ConfirmationEmail : ConfirmationServiceGenericTest<ConfirmationEmail>
    {
        protected override string FileExtension => "eml";
    }
}
