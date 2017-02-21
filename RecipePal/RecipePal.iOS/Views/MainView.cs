// --------------------------------------------------------------------------------------------------------------------
// <summary>
//    Defines the MainView type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace RecipePal.iOS.Views
{
    using Core.ViewModels;
    using MvvmCross.Binding.BindingContext;
    using MvvmCross.iOS.Views;
    using UIKit;

    /// <summary>
    /// Defines the MainView type.
    /// </summary>
    [MvxFromStoryboard]
    public partial class MainView : BaseView
    {
        /// <summary>
        /// Views the did load.
        /// </summary>
        /// <summary>
        /// Called when the View is first loaded
        /// </summary>
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            MvxFluentBindingDescriptionSet<MainView, MainViewModel> set = this.CreateBindingSet<MainView, MainViewModel>();
            set.Bind(this.UiLabel).To(vm => vm.MyProperty);
            set.Bind(this.UiTextField).To(vm => vm.MyProperty);
            set.Apply();

            UITapGestureRecognizer tap = new UITapGestureRecognizer(() => this.View.ResignFirstResponder());
            this.View.AddGestureRecognizer(tap);
        }
    }
}
