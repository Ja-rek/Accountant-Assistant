using System;
using TravelAccountant.Domain.Moneys;
using static Suckless.Asserts.Assertions;

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
            Assert(bookingNumber).NotEmpty();
        }
    }
}
