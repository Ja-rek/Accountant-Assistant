using System;
using System.Collections.Generic;
using TravelAccountant.Domain.Moneys;
using static Suckless.Asserts.Assertions;

namespace TravelAccountant.Domain.Summaries.Ryanair
{
    public class BookingSummary : Summary
    {
        public BookingSummary(DateTime date, 
            string travelNumber, 
            Money amount,
            IEnumerable<string> passengers) 
                : base(49, date, travelNumber, amount, passengers, null)
        {
            Assert(passengers).NotEmpty();
        }
    }
}
