using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Chat_Project
{
    internal class ForumActions
    {
        private IDataHandler DataProvider;
        private User ActiveUser;
        internal ForumActions(IDataHandler DataHandler,User LoggedInUser)
        {
            DataProvider= DataHandler;
            ActiveUser = LoggedInUser;
        }
        public bool CreateMessage()
        {
            Console.WriteLine("Type something");
            string MessageTextToAll = Console.ReadLine();
            ForumMessage MessageForAll = new ForumMessage()
            {
                TextMessageToAll = MessageTextToAll,
                SenderId = ActiveUser.UserID
            };
            return DataProvider.CreateForumMessageData(MessageForAll);
        }
        public bool ShowMyMessages()
        {
            foreach (ForumMessage forumMessage in GetMyMessages())
            {
                Console.WriteLine($"{forumMessage.Sender.Username } you sent at {forumMessage.SendDateToAll}:{forumMessage.TextMessageToAll} ");
            }
            return true;
        }

        public void ShowAllMessages()
        {
            List<string> AllLines = File.ReadLines(@"C:\Users\user\Desktop\ForumMessages.txt").ToList();
            AllLines.ForEach(Console.WriteLine);
        }

        public List<ForumMessage> GetMyMessages()
        {
            return DataProvider.ReadForumMessages()
                .Where(SentMessages => SentMessages.Sender.UserID == ActiveUser.UserID)
                .ToList();
        }

        internal bool UpdateMessage()
        {
            // Choose which message to change
            string TextMessage = SelectMenu.Vertical(GetMyMessages().
                Select(Messages => Messages.TextMessageToAll).ToList());
            // Find the message object
            ForumMessage MessageToReplace = GetMyMessages()
                .Single(MessageTextToReplace => MessageTextToReplace.TextMessageToAll == TextMessage);
            Console.WriteLine("Change your message");
            // Replace the old message text with the new
            string NewMessageText = Console.ReadLine();
            return DataProvider.UpdateForumMessage(MessageToReplace, NewMessageText);
            
        }

        public bool DeleteMessage()
        {
            string TextMessage = SelectMenu.Vertical(GetMyMessages().
               Select(Messages => Messages.TextMessageToAll).ToList());
            ForumMessage MessageToDelete =GetMyMessages()
                .Single(MessageTextToDelete => MessageTextToDelete.TextMessageToAll == TextMessage);           
            return DataProvider.DeleteForumMessage(MessageToDelete,ActiveUser);
        }
    }
}

