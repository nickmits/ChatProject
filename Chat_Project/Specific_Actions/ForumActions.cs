using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Chat_Project
{
    internal class ForumActions
    {
        private IDataHandler DataProvider = new DataHandingOnFile();
        public bool CreateNewMessage(User Sender)
        {

            Console.WriteLine("Type something");
            string MessageTextToAll = Console.ReadLine();
            ForumMessage MessageForAll = new ForumMessage(Sender, MessageTextToAll, DataProvider);
            return DataProvider.CreateForumMessageData(MessageForAll);
        }
        public bool ShowMyMessages(User Sender)
        {

            foreach (ForumMessage forumMessage in GetMyMessages(Sender))
            {
                Console.WriteLine($"{forumMessage.Sender.Username } you sent at {forumMessage.SendDateToAll}:{forumMessage.TextMessageToAll} ");
            }
            return true;
        }

        public void ShowAllMessages(User sender)
        {
            List<string> AllLines = File.ReadLines(@"C:\Users\user\Desktop\ForumMessages.txt").ToList();
            AllLines.ForEach(Console.WriteLine);
        }

        public List<ForumMessage> GetMyMessages(User Sender)
        {
            return DataProvider.ReadForumMessages()
                .Where(SentMessages => SentMessages.Sender.UserID == Sender.UserID)
                .ToList();
        }

        internal string EditMessage(User sender, IDataHandler dataHandler)
        {
            // Choose which message to change
            string TextMessage = SelectMenu.Vertical(GetMyMessages(sender).
                Select(Messages => Messages.TextMessageToAll).ToList());
            // Find the message object
            ForumMessage MessageToReplace = GetMyMessages(sender)
                .Single(MessageTextToReplace => MessageTextToReplace.TextMessageToAll == TextMessage);
            Console.WriteLine("Change your message");
            // Replace the old message text with the new
            string NewMessageText = Console.ReadLine();

            dataHandler.UpdateForumMessage(MessageToReplace, NewMessageText, sender);
            return "Ola good";
        }

        public bool DeleteMessage(ForumMessage forumMessage, IDataHandler dataHandler, User ActiveUser)
        {
            Console.WriteLine("Are you sure to delete this message;");
            return dataHandler.DeleteForumMessage(forumMessage, ActiveUser);
        }
    }
}

