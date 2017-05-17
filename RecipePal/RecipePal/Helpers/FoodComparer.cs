using System;
using System.Collections.Generic;
using RecipePal.Core.Models;

namespace RecipePal.Core.Helpers
{
    public class FoodComparer : IEqualityComparer<Ingredient>
    {
        public bool Equals(Ingredient x, Ingredient y)
        {
            return string.Equals(x.Name, y.Name, StringComparison.InvariantCultureIgnoreCase);
        }

        public int GetHashCode(Ingredient obj)
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + obj.Name.GetHashCode();

                return hash;
            }

        }
    }
}