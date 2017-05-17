using System.Collections.Generic;
using System.Threading.Tasks;
using RecipePal.Core.Models;
using RecipePal.Core.Services.Interfaces;

namespace RecipePal.Core.Services
{
    public class FoodSearchService : IFoodSearchService
    {
        private readonly IRepository _repository;

        public FoodSearchService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<IList<Ingredient>> SearchFood(string ingredientName)
        {
            var searchString = string.IsNullOrEmpty(ingredientName)
                ? ""
                : ingredientName.Trim().ToLowerInvariant();

            var matchedList = await _repository.SearchForIngredients(searchString);

            return matchedList;
        }
    }
}