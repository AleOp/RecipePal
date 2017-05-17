using System.Globalization;
using MvvmCross.Platform.UI;
using MvvmCross.Plugins.Visibility;

namespace RecipePal.Core.Converters
{
    public class DroidListPlaceholderVisibilityConverter : MvxVisibilityValueConverter
    {
        protected override MvxVisibility Convert(object value, object parameter, CultureInfo culture)
        {
            var isVisible = !(bool) value;
            return isVisible ? MvxVisibility.Visible : MvxVisibility.Collapsed;
        }
    }
}