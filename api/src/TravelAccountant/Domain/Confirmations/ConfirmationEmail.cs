using static Suckless.Asserts.Assertions;
using Common.Utils;
using System;

namespace TravelAccountant.Domain.Confirmations
{
    public class ConfirmationEmail : Confirmation
    {
        public ConfirmationEmail(string filePath, 
            string subject,
            DateTime date,
            string content) : base(filePath, content)
        {
            Assert(filePath).EmlFile();
            Assert(subject).NotEmpty();
            Assert(date).NotDefault();

            Subject = subject;
            Date = date;
        }

        public string Subject { get; }
        public DateTime Date { get; }
    }
}
