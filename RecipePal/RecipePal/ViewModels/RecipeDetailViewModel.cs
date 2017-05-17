using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Plugins.Messenger;
using RecipePal.Core.Helpers;
using RecipePal.Core.Messages;
using RecipePal.Core.Models;
using RecipePal.Core.Services.Interfaces;

namespace RecipePal.Core.ViewModels
{
    public class RecipeDetailViewModel : BaseCustomViewModel<Recipe>
    {
        private readonly IRepository _repository;
        private string _imageUrl;
        private bool _isFavorite;
        private Dictionary<int, ICollection<IDataEntity>> _recipeDictionary;
        private int _recipeTag;
        private string _title;
        private IMvxAsyncCommand _toggleToFavoriteAsyncCommand;
        private string _userId;


        public RecipeDetailViewModel(IRepository repository)
        {
            _repository = repository;
        }

        public Dictionary<int, ICollection<IDataEntity>> RecipeDictionary
        {
            get { return _recipeDictionary; }
            set { SetProperty(ref _recipeDictionary, value); }
        }

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public string ImageUrl
        {
            get { return _imageUrl; }
            set { SetProperty(ref _imageUrl, value); }
        }

        public IMvxAsyncCommand ToggleFavoriteAsyncCommand
        {
            get
            {
                _toggleToFavoriteAsyncCommand = _toggleToFavoriteAsyncCommand ??
                                                new MvxAsyncCommand(ToggleFavoriteAsyncCommandHandler);
                return _toggleToFavoriteAsyncCommand;
            }
        }


        protected override async void InitWithReceivedData(Recipe @object)
        {
            Title = @object.Name;
            ImageUrl = @object.PhotoUrl;

            _userId = Mvx.Resolve<IAzureClientService>().CurrentClient.CurrentUser.UserId.Replace("sid:", "");
            _recipeTag = @object.Tag;

            var recipeDict = new Dictionary<int, ICollection<IDataEntity>>();

            if (!recipeDict.ContainsKey((int) RecipeDictionaryKey.Recipe))
                recipeDict.Add((int) RecipeDictionaryKey.Recipe,
                    new Collection<IDataEntity> {@object});

            var ingredients = await GetIngredientsForRecipe(@object, recipeDict);

            await GetQuatityTypesForRecipe(ingredients, recipeDict);

            RecipeDictionary =
                new Dictionary<int, ICollection<IDataEntity>>(recipeDict);
            
            await CheckIfFavorite(@object.Tag);
        }

        private async Task GetQuatityTypesForRecipe(IList<Ingredient> ingredients, 
            Dictionary<int, ICollection<IDataEntity>> recipeDict)
        {
            var ingredientsQuantity = await _repository.GetQuantitiesByIngredientTagAsync(ingredients);

            if (!recipeDict.ContainsKey((int) RecipeDictionaryKey.QuantityTypes))
                recipeDict.Add((int) RecipeDictionaryKey.QuantityTypes,
                    new Collection<IDataEntity>(ingredientsQuantity.Cast<IDataEntity>().ToList()));
        }

        private async Task<IList<Ingredient>> GetIngredientsForRecipe(Recipe @object, 
            Dictionary<int, ICollection<IDataEntity>> recipeDict)
        {
            var ingredients = await _repository.GetIngredientsByRecipeTag(@object.Tag);

            if (!recipeDict.ContainsKey((int) RecipeDictionaryKey.Ingredients))
                recipeDict.Add((int) RecipeDictionaryKey.Ingredients,
                    new Collection<IDataEntity>(ingredients.Cast<IDataEntity>().ToList()));

            return ingredients;
        }

        private async Task CheckIfFavorite(int recipeTag)
        {
            _isFavorite = await _repository.CheckIfFavouriteRecipe(recipeTag, _userId);

            Mvx.Resolve<IMvxMessenger>()
                .Publish(new ChangeFavoriteBtnImageMessage(this, _isFavorite));
        }

        private async Task ToggleFavoriteAsyncCommandHandler()
        {
            if (_isFavorite)
            {
                await _repository.DeleteFavoriteItemAsync(_userId, _recipeTag);
                _isFavorite = false;
                Mvx.Resolve<IMvxMessenger>()
                    .Publish(new ChangeFavoriteBtnImageMessage(this, _isFavorite));
            }
            else
            {
                await _repository.SaveFavorite(new Favorites {RecipeTag = _recipeTag, UserId = _userId});
                _isFavorite = true;
                Mvx.Resolve<IMvxMessenger>()
                    .Publish(new ChangeFavoriteBtnImageMessage(this, _isFavorite));
            }
        }
    }
}