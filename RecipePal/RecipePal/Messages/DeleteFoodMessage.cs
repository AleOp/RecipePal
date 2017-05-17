using MvvmCross.Plugins.Messenger;

namespace RecipePal.Core.Messages
{
    public class DeleteFoodMessage : MvxMessage
    {
        public string FoodItem { get; }      

        public DeleteFoodMessage(object sender, string foodItem) : base(sender)
        {
            FoodItem = foodItem;
         
        }
       
    }
}