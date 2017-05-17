using MvvmCross.Plugins.Messenger;

namespace RecipePal.Core.Messages
{
    public class ChangeFavoriteBtnImageMessage : MvxMessage
    {
        public bool IsRecipeFavorite { get; }

        public ChangeFavoriteBtnImageMessage(object sender, bool isRecipeFavorite) : base(sender)
        {
            IsRecipeFavorite = isRecipeFavorite;
        }
    }
}