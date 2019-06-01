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
            string number, 
            Money amount,
            IEnumerable<string> passengers,
            string bookingNumber) 
        {
            Assert(contractorPosition).Positive();
            Assert(date).NotDefault();
            Assert(number).NotEmpty();
            Assert(passengers).NotEmpty();
            Assert(bookingNumber).NotEmpty();
            AssertNotNull(amount);

            ContractorPosition = contractorPosition;
            Date = date;
            Number = number;
            Amount = amount;
            Passengers = passengers;
            BookingNumber = bookingNumber;
        }

        public int ContractorPosition { get; }
        public DateTime Date { get; }
        public string Number { get; }
        public Money Amount { get; }
        public IEnumerable<string> Passengers { get; }
        public string BookingNumber { get; }
    }
}
