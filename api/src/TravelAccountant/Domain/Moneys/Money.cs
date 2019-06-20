using System;
using static Suckless.Asserts.Assertions;

namespace TravelAccountant.Domain.Moneys
{
    public class Money
    {
        public Money(decimal value, string currency)
        {
            Assert(currency).NotEmpty();

            Value = value;
            Currency = currency.Replace(" ", string.Empty);
        }

        public decimal Value { get; }
        public string Currency { get; }

        public override bool Equals(object obj)
        {
            switch (obj)
            {
                case Money money:
                    return  money.Value == Value && money.Currency == Currency;

                case decimal value:
                    return  value == Value;
            
                default:
                    return false;
            }
        }

        public static Money operator +(Money left, Money right) 
        {
            if (left.Currency != right.Currency)
            {
                throw new ApplicationException($"Wrong currency format: {left.Currency} is not equal to {right.Currency}.");
            }

            return new Money(left.Value + right.Value, right.Currency);
        }

        public static bool operator ==(Money left, Money right) => left.Equals(right);
        public static bool operator !=(Money left, Money right) => !left.Equals(right);

        public static bool operator ==(Money left, decimal right) => left.Equals(right);
        public static bool operator !=(Money left, decimal right) => !left.Equals(right);

        public static bool operator ==(decimal left, Money right) => right.Equals(left);
        public static bool operator !=(decimal left, Money right) => !right.Equals(left);

        public override int GetHashCode() => Currency.GetHashCode() * Value.GetHashCode();
    }
}
