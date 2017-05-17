using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using RecipePal.Core.Models;
using RecipePal.Core.Services.Interfaces;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using Microsoft.WindowsAzure.MobileServices.Sync;
using RecipePal.Core.Helpers;

namespace RecipePal.Core.Services
{
    public class Repository : IRepository
    {
        private readonly IMobileServiceSyncTable<Category> _categoriesTable;
        private readonly IMobileServiceSyncTable<Recipe> _recipiesTable;
        private readonly IMobileServiceSyncTable<Favorites> _favoritesTable;
        private readonly IMobileServiceSyncTable<Ingredient> _ingredientsTable;
        private readonly IMobileServiceSyncTable<QuantityType> _quantityTypeTable;
        private readonly IMobileServiceSyncTable<User> _userTable;
        private readonly IMobileServiceClient _client;

        private const string OfflineDbPath = @"recipepal.db";


        public Repository(IAzureClientService azureClient)
        {
            _client = azureClient.CurrentClient;

            var store = new MobileServiceSQLiteStore(OfflineDbPath);

            store.DefineTable<Category>();
            store.DefineTable<Recipe>();
            store.DefineTable<Favorites>();
            store.DefineTable<Ingredient>();
            store.DefineTable<QuantityType>();
            store.DefineTable<User>();

            _client.SyncContext.InitializeAsync(store);

            _categoriesTable = _client.GetSyncTable<Category>();
            _recipiesTable = _client.GetSyncTable<Recipe>();
            _favoritesTable = _client.GetSyncTable<Favorites>();
            _ingredientsTable = _client.GetSyncTable<Ingredient>();
            _quantityTypeTable = _client.GetSyncTable<QuantityType>();
            _userTable = _client.GetSyncTable<User>();
        }

        public async Task<bool> DeleteDataFromDatabase()
        {
            var success = true;
            try
            {
                await _recipiesTable.PurgeAsync(true);
                await _categoriesTable.PurgeAsync(true);
                await _favoritesTable.PurgeAsync(true);
                await _ingredientsTable.PurgeAsync(true);
                await _quantityTypeTable.PurgeAsync(true);
                await _categoriesTable.PurgeAsync(true);
            }
            catch (Exception e)
            {
                success = false;
            }

            return success;
        }


        public async Task<IList<Ingredient>> SearchForIngredients(string searchString)
        {
            if (searchString == "")
                return new List<Ingredient>();

            var result = await _ingredientsTable.Select(x => x)
                .Where(x => x.Name.Contains(searchString))
                .ToListAsync();

            return result == null
                ? new List<Ingredient>()
                : new List<Ingredient>(result);
        }

        public async Task SaveItemsAsync(IDataEntity item, ModelTableNames tableName)
        {
            switch (tableName)
            {
                case ModelTableNames.Category:
                    await CheckAndSaveItem((Category) item, _categoriesTable);
                    break;
                case ModelTableNames.User:
                    await CheckAndSaveItem((User) item, _userTable);
                    break;
                case ModelTableNames.Favorites:
                    await CheckAndSaveItem((Favorites) item, _favoritesTable);
                    break;
                case ModelTableNames.Ingredient:
                    await CheckAndSaveItem((Ingredient) item, _ingredientsTable);
                    break;
                case ModelTableNames.QuantityType:
                    await CheckAndSaveItem((QuantityType) item, _quantityTypeTable);
                    break;
                case ModelTableNames.Recipe:
                    await CheckAndSaveItem((Recipe) item, _recipiesTable);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(tableName));
            }
        }

        public async Task DeleteFavoriteItemAsync(string userId, int recipeTag)
        {
            var instance = await _favoritesTable.Select(x => x)
                .Where(x => x.RecipeTag == recipeTag && x.UserId == userId)
                .ToListAsync();

            foreach (var item in instance)
            {
                await _favoritesTable.DeleteAsync(item);

            }

        }

        public async Task SaveFavorite(Favorites favorite)
        {
           var lookupFormClone =  await _favoritesTable.Where(x => x.UserId == favorite.UserId && x.RecipeTag == favorite.RecipeTag).ToListAsync();
            if (lookupFormClone.Count == 0)
                await _favoritesTable.InsertAsync(favorite);

        }

        private async Task CheckAndSaveItem<T>(T item, IMobileServiceSyncTable<T> table) where T : IDataEntity
        {
            try
            {
                if (item.Id == null)
                {
                    await table.InsertAsync(item);
                }
                else
                {
                    await table.UpdateAsync(item);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
        }

        public async Task<IList<Ingredient>> GetIngredientsByRecipeTag(int recipeTag)
        {
            var result = await _ingredientsTable.Where(x => x.RecipeTag == recipeTag).ToListAsync();
            return result ?? new List<Ingredient>();
        }

        public async Task<IList<QuantityType>> GetQuantitiesByIngredientTagAsync(IList<Ingredient> ingredients)
        {
            var result = new List<QuantityType>();
            foreach (var ingredient in ingredients)
            {
                var quantities = await _quantityTypeTable.Where(x => x.Tag == ingredient.QuantityTag).ToListAsync();
                result.AddRange(quantities);
            }
            
            return result;
        }
     

        public async Task<bool> CheckIfFavouriteRecipe(int recipeTag, string userId)
        {
            var result = await _favoritesTable.Where(x => x.UserId == userId && x.RecipeTag == recipeTag).ToListAsync();
            return result != null && result.Count >= 1;
        }

        public async Task<IList<int>> GetFavoritesRecipesTagsAsync(string userId)
        {
            var result = await _favoritesTable.Where(x => x.UserId == userId).Select(x => x.RecipeTag).ToListAsync();
            return result ?? new List<int>();
        }

        public async Task<IList<Recipe>> GetRecipesByCategoryAsync(int categoryTag)
        {
            var matchedRecipes = new List<Recipe>();

            var result = await _recipiesTable.Select(x => x).Where(x => x.CategoryTag == categoryTag).ToListAsync();

            if (result != null)
                matchedRecipes.AddRange(result);


            return matchedRecipes;
        }

        public async Task<IList<Recipe>> GetRecipesThatMatchAsync(IList<int> recipesTags)
        {
            var matchedRecipes = new List<Recipe>();

            foreach (var recipeTag in recipesTags)
            {
                var result = await _recipiesTable.Select(x => x).Where(x => x.Tag == recipeTag).ToListAsync();

                if (result != null)
                    matchedRecipes.AddRange(result);
            }

            return matchedRecipes;
        }

        public async Task<IList<IDataEntity>> GetAllItemsAsync(string queryId, ModelTableNames tableName)
        {
            switch (tableName)
            {
                case ModelTableNames.User:
                    return await GetAllItemsAsyncHelper(_userTable, queryId);
                case ModelTableNames.Category:
                    return await GetAllItemsAsyncHelper(_categoriesTable, queryId);
                case ModelTableNames.Favorites:
                    return await GetAllItemsAsyncHelper(_favoritesTable, queryId);
                case ModelTableNames.Ingredient:
                    return await GetAllItemsAsyncHelper(_ingredientsTable, queryId);
                case ModelTableNames.QuantityType:
                    return await GetAllItemsAsyncHelper(_quantityTypeTable, queryId);
                case ModelTableNames.Recipe:
                    return await GetAllItemsAsyncHelper(_recipiesTable, queryId);
                default:
                    throw new ArgumentOutOfRangeException(nameof(tableName));
            }
        }

        private async Task<IList<IDataEntity>> GetAllItemsAsyncHelper<T>(IMobileServiceSyncTable<T> table,
            string queryId)
            where T : IDataEntity
        {
            try
            {
                await SyncAsync(table, queryId);

                var items = await table.ToEnumerableAsync();

                return new List<IDataEntity>((IEnumerable<IDataEntity>) items);
            }
            catch (MobileServiceInvalidOperationException serviceInvalidOperationException)
            {
                Debug.WriteLine("Invalid sync operation: {0}", 
                    serviceInvalidOperationException.Message);
            }
            catch (Exception e)
            {
                Debug.WriteLine("Sync error: {0}", e.Message);
            }
            return null;
        }

        private async Task SyncAsync<T>(IMobileServiceSyncTable<T> table, string queryId) where T : IDataEntity
        {
            ReadOnlyCollection<MobileServiceTableOperationError> syncErrors = null;

            try
            {
                await _client.SyncContext.PushAsync();

                await table.PullAsync(queryId, table.CreateQuery());
            }
            catch (MobileServicePushFailedException exc)
            {
                if (exc.PushResult != null)
                {
                    syncErrors = exc.PushResult.Errors;
                }
            }

            if (syncErrors != null)
            {
                foreach (var error in syncErrors)
                {
                    if (error.OperationKind == MobileServiceTableOperationKind.Update && error.Result != null)
                    {
                        await error.CancelAndUpdateItemAsync(error.Result);
                    }
                    else
                    {
                        await error.CancelAndDiscardItemAsync();
                    }
                }
            }
        }

        public async Task SyncRequiredTablesAtStartup()
        {
            await SyncAsync(_recipiesTable, "syncallrecipes");
            await SyncAsync(_quantityTypeTable, "syncallquantuties");
            await SyncAsync(_ingredientsTable, "syncallingredients");
            
        }
    }
}