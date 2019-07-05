using System;
using TravelAccountant.Domain.Moneys;

namespace TravelAccountant.Domain.Summaries.Wizzair
{
    public class InvoiceSummary : Summary
    {
        public InvoiceSummary(DateTime date, 
            string invoiceNumber, 
            Money amount,
            string bookingNumber) 
                : base(2, date, invoiceNumber, amount, null, bookingNumber)
        {
        }
    }
}
