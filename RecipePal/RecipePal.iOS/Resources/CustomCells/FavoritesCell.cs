using System;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using RecipePal.Core.Converters;
using RecipePal.Core.Models;

namespace RecipePal.iOS.Resources.CustomCells
{
    public partial class FavoritesCell : MvxTableViewCell
    {
        public FavoritesCell(IntPtr handle) : base(handle)
        {
            this.DelayBind(() =>
            {
                var bindingSet = this.CreateBindingSet<FavoritesCell, Recipe>();
                bindingSet.Bind(RecipeName)
                    .To(v => v.Name);
                bindingSet.Bind(RecipeImage)
                    .For(v => v.ImageUrl)
                    .To(v => v.PhotoUrl);
                bindingSet.Bind(RecipeCookTime)
                    .To(v => v.CookTime)
                    .WithConversion(new CookTimeAttributeValueConverter());
                bindingSet.Apply();
            });
        }
    }
}