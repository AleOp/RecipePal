using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Platform.Platform;

namespace RecipePal.Core.ViewModels
{
    public abstract class BaseCustomViewModel<TInit>
        : MvxViewModel
    {
        public void Init(string serializedObject)
        {
            var deserializedObject = 
                Mvx.Resolve<IMvxJsonConverter>().DeserializeObject<TInit>(serializedObject);

            InitWithReceivedData(deserializedObject);
        }

        protected abstract void InitWithReceivedData(TInit @object);

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