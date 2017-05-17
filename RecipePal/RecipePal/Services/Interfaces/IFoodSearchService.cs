using System.Collections.Generic;
using System.Threading.Tasks;
using RecipePal.Core.Models;

namespace RecipePal.Core.Services.Interfaces
{
    public interface IFoodSearchService
    {
        Task<IList<Ingredient>> SearchFood(string ingredientName);
    }
}