using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecipePal.Core.Models;
using RecipePal.Core.Services.Interfaces;

namespace RecipePal.Core.Services
{
    public class MatchRecipeService : IMatchRecipeService
    {
        private readonly IRepository _repository;

        public MatchRecipeService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Tuple<IList<Recipe>, IList<Recipe>>> MatchRecipes(
            Dictionary<string, List<int>> ingredientsDictionary)
        {
            var recipesIngrSum = FindIngredientsSumForEachRecipe(ingredientsDictionary);
            var fetchFoundRecipes = await FetchRecipesFromDbWithSpecifiedIdAsync(recipesIngrSum);
            var matchedRecipesTuple = CheckRecipesForSufficientIngredients(fetchFoundRecipes, recipesIngrSum);

            return matchedRecipesTuple;
        }

        private static Dictionary<int, int> FindIngredientsSumForEachRecipe(
            Dictionary<string, List<int>> ingredientsDictionary)
        {
            var recipesIngredientsSum = new Dictionary<int, int>();

            foreach (var ingredientsKey in ingredientsDictionary)
            {
                foreach (var recipieId in ingredientsKey.Value)
                {
                    if (!recipesIngredientsSum.ContainsKey(recipieId))
                        recipesIngredientsSum.Add(recipieId, 1);
                    else
                        recipesIngredientsSum[recipieId]++;
                }
            }
            return recipesIngredientsSum;
        }

        private async Task<IList<Recipe>> FetchRecipesFromDbWithSpecifiedIdAsync(Dictionary<int, int> recipesIngrSum)
        {
            var result = await _repository.GetRecipesThatMatchAsync(recipesIngrSum.Keys.ToList());
            return result;
        }

        private static Tuple<IList<Recipe>, IList<Recipe>> CheckRecipesForSufficientIngredients(
            IEnumerable<Recipe> fetchFoundRecipes,
            Dictionary<int, int> recipesIngrSum)
        {
            if (recipesIngrSum == null)
                throw new ArgumentNullException(nameof(recipesIngrSum));

            IList<Recipe> fullMatched = new List<Recipe>();
            IList<Recipe> partyMatched = new List<Recipe>();

            foreach (var foundRecipe in fetchFoundRecipes)
            {
                if (foundRecipe.IngredientsNumber == recipesIngrSum[foundRecipe.Tag])
                    fullMatched.Add(foundRecipe);

                else if (foundRecipe.IngredientsNumber - recipesIngrSum[foundRecipe.Tag] <= 5)
                    partyMatched.Add(foundRecipe);
            }
            return Tuple.Create(fullMatched, partyMatched);
        }
    }
}