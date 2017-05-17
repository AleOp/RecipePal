using System;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;

namespace RecipePal.iOS.Resources.CustomCells
{
    public partial class FoodStuffCell : MvxTableViewCell
    {
        public FoodStuffCell(IntPtr handle) : base(handle)
        {
            this.DelayBind(() =>
            {
                var bindingSet = this.CreateBindingSet<FoodStuffCell, string>();
                bindingSet.Bind(IngredientName).To(v => v).Apply();
                
            });
        }
    }
}