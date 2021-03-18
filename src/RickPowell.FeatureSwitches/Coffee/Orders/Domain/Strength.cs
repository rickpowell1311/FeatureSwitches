using System;

namespace RickPowell.FeatureSwitches.Coffee.Orders.Domain
{
    public class Strength 
    {
        public static Strength Weak => new Strength(0.02m);

        public static Strength Normal => new Strength(0.03m);

        public static Strength Strong => new Strength(0.04m);

        public decimal Kilograms { get; }

        public Strength(decimal kilograms)
        {
            Kilograms = kilograms;
        }

        public override bool Equals(object obj)
        {
            return obj is Strength strength && Equals(strength);
        }

        public bool Equals(Strength other)
        {
            return this == other;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Kilograms);
        }

        public static bool operator ==(Strength first, Strength second)
        {
            return first?.Kilograms == second?.Kilograms;
        }

        public static bool operator !=(Strength first, Strength second)
        {
            return !(first == second);
        }
    }
}
