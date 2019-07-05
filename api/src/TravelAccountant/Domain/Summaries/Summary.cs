using System;
using System.Collections.Generic;
using static Suckless.Asserts.Assertions;
using TravelAccountant.Domain.Moneys;

namespace TravelAccountant.Domain.Summaries
{
    public abstract class Summary
    {
        public Summary(
            int contractorPosition, 
            DateTime date, 
            string travelNumber, 
            Money amount,
            IEnumerable<string> passengers,
            string bookingNumber) 
        {
            Assert(contractorPosition).Positive();
            Assert(date).NotDefault();
            Assert(travelNumber).NotEmpty();
            AssertNotNull(amount);

            ContractorPosition = contractorPosition;
            Date = date;
            DocumentNumber = travelNumber;
            Amount = amount;
            Passengers = passengers;
            BookingNumber = bookingNumber;
        }

        public int ContractorPosition { get; }
        public DateTime Date { get; }
        public string DocumentNumber { get; }
        public Money Amount { get; }
        public IEnumerable<string> Passengers { get; }
        public string BookingNumber { get; }
    }
}
