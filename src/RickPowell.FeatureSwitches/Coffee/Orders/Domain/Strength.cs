using System;

namespace RickPowell.FeatureSwitches.Coffee.Orders.Domain
{
    public class Strength 
    {
        public static Strength Weak => new Strength(0.02m);

        public static Strength Normal => new Strength(0.03m);

        public static Strength Strong => new Strength(0.04m);

        public decimal KilogramsOfCoffee { get; }

        public Strength(decimal kilograms)
        {
            KilogramsOfCoffee = kilograms;
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
            return HashCode.Combine(KilogramsOfCoffee);
        }

        public static bool operator ==(Strength first, Strength second)
        {
            return first?.KilogramsOfCoffee == second?.KilogramsOfCoffee;
        }

        public static bool operator !=(Strength first, Strength second)
        {
            return !(first == second);
        }
    }
}
