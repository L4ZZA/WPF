namespace BaseWindow.ViewModels.Chat.Design
{
    /// <summary>
    /// the design-time data for a <see cref="ChatListItemViewModel"/>
    /// </summary>
    public class ChatListItemDesignModel : ChatListItemViewModel
    {

        #region Singletone

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static ChatListItemDesignModel Instance { get; } = new ChatListItemDesignModel();

        #endregion

        #region Contructor

        /// <summary>
        /// 
        /// </summary>
        public ChatListItemDesignModel()
        {
            Initials = "LM";
            Name = "Luke";
            Message = "This new chat app is awesome! I bet it will be fasst too";
            ProfilePictureRGB = "3099c5";
        }

        #endregion
    }
}