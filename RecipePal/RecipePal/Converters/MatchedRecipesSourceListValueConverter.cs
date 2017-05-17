using System;
using System.Collections.Generic;
using System.Globalization;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.Converters;
using RecipePal.Core.Models;

namespace RecipePal.Core.Converters
{
    public class MatchedRecipesSourceListValueConverter :
        MvxValueConverter<Dictionary<int, MvxObservableCollection<Recipe>>, MvxObservableCollection<Recipe>>
    {
        protected override MvxObservableCollection<Recipe> Convert(
            Dictionary<int, MvxObservableCollection<Recipe>> value, Type targetType, object parameter,
            CultureInfo culture)
        {
            var conjuctionList = new MvxObservableCollection<Recipe>(value[0]);
            conjuctionList.AddRange(value[1]);
            return new MvxObservableCollection<Recipe>(conjuctionList);
        }
    }
}