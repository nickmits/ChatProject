using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Chat_Project
{
    class ForumMessage
    {
        internal User Sender;
        public int ForumMessageId { get; set; }
        private static int CountIdMessage;
        public string TextMessageToAll;
        public DateTime SendDateToAll;

        private IDataHandler DataProvider = new DataHandingOnFile();

        public int GetLastMessageID()
        {            
            return CountIdMessage=DataProvider.ReadForumMessages().LastOrDefault().ForumMessageId;
        }
        

        public ForumMessage(User NewSender, string NewTextMessageToAll, IDataHandler DataProvider)
        {
            this.DataProvider = DataProvider;
            Sender = NewSender;
            TextMessageToAll = NewTextMessageToAll;
            SendDateToAll = DateTime.Now;            
            CountIdMessage++;
            CountIdMessage = ForumMessageId;
            DataProvider.CreateForumMessageData(this);
        }

        public ForumMessage(int SenderID, int MessageID, string NewTextMessageToAll, DateTime DateCreated)
        {
            Sender = DataProvider.ReadUserData().SingleOrDefault(TheUserSender => TheUserSender.UserID == SenderID);
            TextMessageToAll = NewTextMessageToAll;
            SendDateToAll = DateCreated;          
        }

    

    }
}
