using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RecipePal.Core.Models;

namespace RecipePal.Core.Services.Interfaces
{
    public interface IMatchRecipeService
    {
        Task<Tuple<IList<Recipe>, IList<Recipe>>> MatchRecipes(Dictionary<string, List<int>> ingredientsDictionary);
    }
}