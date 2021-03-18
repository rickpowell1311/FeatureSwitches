using System;

namespace RickPowell.FeatureSwitches.Coffee.Orders.Domain
{
    public class Cost : IEquatable<Cost>
    {
        public decimal Amount { get; protected set; }

        public Currency Currency { get; protected set; }

        public Cost(decimal amount, Currency currency)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("amount", "'amount' should be a positive value");
            }

            Amount = amount;
            Currency = currency;
        }

        public override bool Equals(object obj)
        {
            return obj is Cost cost && Equals(cost);
        }

        public bool Equals(Cost other)
        {
            return this == other;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Amount, Currency);
        }

        public static bool operator ==(Cost first, Cost second)
        {
            return first?.Amount == second?.Amount
                && first?.Currency == second?.Currency;
        }

        public static bool operator !=(Cost first, Cost second)
        {
            return !(first == second);
        }

        public static Cost operator *(Cost cost, decimal multiplier)
        {
            return new Cost(cost.Amount * multiplier, cost.Currency);
        }

        public static Cost operator *(decimal multiplier, Cost cost)
        {
            return new Cost(cost.Amount * multiplier, cost.Currency);
        }
    }
}
