using System;
using System.IO;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using RecipePal.Core.Models;

namespace RecipePal.iOS.Resources.CustomCells
{
    public partial class CategoriesCell : MvxTableViewCell
    {
        public CategoriesCell(IntPtr handle) : base(handle)
        {
            this.DelayBind(() =>
            {
                CategoryImage.DefaultImagePath =
                    Path.Combine(NSBundle.MainBundle.BundlePath, "MiscellaneousImg", "DefaultFood");

                var bindings = this.CreateBindingSet<CategoriesCell, Category>();
                bindings.Bind(CategoryName).To(vm => vm.Name);
                bindings.Apply();
            });
        }
    }
}