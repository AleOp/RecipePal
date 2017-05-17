using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Platform.Platform;

namespace RecipePal.Core.ViewModels
{
    public class BaseCustomViewModel
        : MvxViewModel
    {
        protected void ShowViewModel<TViewModel>(object transferedObject)
            where TViewModel : IMvxViewModel
        {
            var text = Mvx.Resolve<IMvxJsonConverter>().SerializeObject(transferedObject);
            base.ShowViewModel<TViewModel>(new {serializedObject = text});
        }
        public virtual void AndroidCloseHandler()
        {
            Close(this);
        }
    }
}