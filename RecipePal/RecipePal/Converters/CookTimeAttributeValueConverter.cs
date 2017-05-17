using System;
using System.Globalization;
using MvvmCross.Platform.Converters;

namespace RecipePal.Core.Converters
{
    public class CookTimeAttributeValueConverter : MvxValueConverter<int, string>
    {
        protected override string Convert(int value, Type targetType, object parameter, CultureInfo culture)
        {
            return $"{value} min";
        }
    }
}