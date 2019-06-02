using Npoi.Mapper;

namespace TravelAccountant.Infrastructure.Summaries
{
    public class SummaryMapping
    {
        public static Mapper Mapper(string currency)
        {
            return new Mapper()
                .Map<SummaryExelPersistence>("Kontrahent Pozycja Symfonia", x => x.ContractorPosition)

                .Map<SummaryExelPersistence>("Data wpływu", x => x.PaymentReceiptDate)
                .Format<SummaryExelPersistence>("dd/MM/yyyy", x => x.PaymentReceiptDate)

                .Map<SummaryExelPersistence>("Data dokumentu", x => x.DocumentDate)
                .Format<SummaryExelPersistence>("dd/MM/yyyy", x => x.DocumentDate)

                .Map<SummaryExelPersistence>("Data operacji gospodarczej", x => x.BusinessOperationDate)
                .Format<SummaryExelPersistence>("dd/MM/yyyy", x => x.BusinessOperationDate)

                .Map<SummaryExelPersistence>("Document No.", x => x.DocumentNumber)

                .Map<SummaryExelPersistence>("Original Amount", x => x.OriginalAmount)
                .Format<SummaryExelPersistence>($"#,##0.00 \"{currency}\";[RED]-#,##0.00 \"{currency}\"", x => x.OriginalAmount)

                .Map<SummaryExelPersistence>("Due Date", x => x.DueDate)
                .Format<SummaryExelPersistence>("dd/MM/yyyy", x => x.DueDate)
                .Map<SummaryExelPersistence>("Gen. Prod. Posting Group", x => x.PostingGroup);
        }
    }
}
