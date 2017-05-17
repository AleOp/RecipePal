using System.Collections.Generic;
using System.Threading.Tasks;
using RecipePal.Core.Helpers;
using RecipePal.Core.Models;

namespace RecipePal.Core.Services.Interfaces
{
    public interface IRepository
    {
        Task<IList<Ingredient>> SearchForIngredients(string searchString);
        Task SaveItemsAsync(IDataEntity item, ModelTableNames tableName);
        Task<IList<IDataEntity>> GetAllItemsAsync(string queryId, ModelTableNames tableName);
        Task SyncRequiredTablesAtStartup();
        Task<IList<Recipe>> GetRecipesThatMatchAsync(IList<int> recipesTags);
        Task<IList<int>> GetFavoritesRecipesTagsAsync(string userId);
        Task<IList<Recipe>> GetRecipesByCategoryAsync(int categoryTag);
        Task<IList<Ingredient>> GetIngredientsByRecipeTag(int recipeTag);
        Task<IList<QuantityType>> GetQuantitiesByIngredientTagAsync(IList<Ingredient> ingredients);
        Task<bool> CheckIfFavouriteRecipe(int recipeTag, string userId);
        Task<bool> DeleteDataFromDatabase();
        Task DeleteFavoriteItemAsync(string userId, int recipeTag);
        Task SaveFavorite(Favorites favorite);
    }
}