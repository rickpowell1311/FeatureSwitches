using System;
using System.Collections.Generic;

namespace RickPowell.FeatureSwitches.Coffee.Orders.Domain
{
    public class Blend
    {
        public int Id { get; protected set; }

        public string Name { get; protected set; }

        public Cost BaseCost { get; protected set; }

        protected Blend()
        {
        }

        public static Blend Create(string name, Cost baseCost)
        {
            return new Blend
            {
                Name = name,
                BaseCost = baseCost
            };
        }

        public Func<Strength, Cost> GetCost(bool useExperimentalCosting)
        {
            if (useExperimentalCosting)
            {
                return GetExperimentalCost;
            }

            return GetCost;
        }

        private Cost GetCost(Strength strength)
        {
            var costMultipliers = new Dictionary<Strength, decimal>
            {
                { Strength.Weak, 0.8m },
                { Strength.Normal, 1.0m },
                { Strength.Strong, 1.2m }
            };

            return costMultipliers[strength] * BaseCost;
        }

        private Cost GetExperimentalCost(Strength strength)
        {
            var costMultipliers = new Dictionary<Strength, decimal>
            {
                { Strength.Weak, 0.7m },
                { Strength.Normal, 1.0m },
                { Strength.Strong, 1.3m }
            };

            return costMultipliers[strength] * BaseCost;
        }
    }
}
