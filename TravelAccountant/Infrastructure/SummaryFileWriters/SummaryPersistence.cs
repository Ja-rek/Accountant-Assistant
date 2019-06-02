using System;
using System.Linq;
using TravelAccountant.Domain.Summaries;

namespace TravelAccountant.Infrastructure.Summaries
{
    public class SummaryExelPersistence
    {
        public SummaryExelPersistence(Summary summary)
        {
            ContractorPosition = summary.ContractorPosition;
            DocumentDate = summary.Date;
            BusinessOperationDate = summary.Date;
            DocumentNumber = summary.TravelNumber;
            OriginalAmount = summary.Amount.Value;
            PaymentReceiptDate = null;
            DueDate = null;
            BookingNumber = summary?.BookingNumber;
            Passenger = summary
                ?.Passengers
                ?.Aggregate((x, y) => $"{x}, {y}");
        }

        public int ContractorPosition { get; }
        public DateTime DocumentDate { get; }
        public DateTime? PaymentReceiptDate { get; }
        public DateTime BusinessOperationDate { get; }
        public string DocumentNumber { get; }
        public string Description { get; }
        public decimal OriginalAmount { get; }
        public DateTime? DueDate { get; }
        public string PostingGroup { get; }
        public string BookingNumber { get; }
        public string Passenger { get; }
    }
}
