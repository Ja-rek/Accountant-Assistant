using System;
using System.Collections.Generic;
using TravelAccountant.Domain.Moneys;

namespace TravelAccountant.Domain.Summaries.Ryanair
{
    public class BookingSummary : Summary
    {
        public BookingSummary(DateTime date, 
            string number, 
            Money amount,
            IEnumerable<string> passengers) 
                : base(49, date, number, amount, passengers, null)
        {
        }
    }
}
