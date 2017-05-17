using System;
using System.Collections.Generic;
using System.Globalization;
using MvvmCross.Platform.Converters;
using RecipePal.Core.Models;

namespace RecipePal.Core.Converters
{
    public class RecipeDetailItemSourceValueConverter :
        MvxValueConverter<Dictionary<int, ICollection<IDataEntity>>, IEnumerable<int>>
    {
        protected override IEnumerable<int> Convert(
            Dictionary<int, ICollection<IDataEntity>> value, Type targetType, object parameter,
            CultureInfo culture)
        { 
            if (value?.Keys.Count > 0)
                return new List<int> (value.Keys);

            return new List<int>();
        }
    }
}
