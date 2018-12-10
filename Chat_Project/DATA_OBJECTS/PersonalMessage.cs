using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Chat_Project
{
    class PersonalMessage
    {
        internal User Sender;
        internal User Receiver;
        public string PersonalMessageText;
        internal bool isRead;
        internal DateTime SendDate;
        internal DateTime ReadDate;
        public int PersonalMessageId { get; set; }
        public static int CountIDPersonalMessage { get; set; }
        IDataHandler dataHander = new DataHandingOnFile();
       

        public PersonalMessage(User NewSender, User NewReceiver, string NewMessageText)
        {            
            Sender = NewSender;
            Receiver = NewReceiver;
            PersonalMessageText = NewMessageText;
            SendDate = DateTime.Now;
            CountIDPersonalMessage++;
            PersonalMessageId = CountIDPersonalMessage;
            isRead = false;
            SavePersonalMessage();
        }
        
        public PersonalMessage(int SenderID,int RecceiverID , string NewExistingPersonalMessage,DateTime SentDate)
        {
            
            Receiver =dataHander.ReadUserData().SingleOrDefault(TheUserReceiver => TheUserReceiver.UserID ==RecceiverID);
            Sender = dataHander.ReadUserData().SingleOrDefault(TheUserSender => TheUserSender.UserID == SenderID);          
            PersonalMessageText = NewExistingPersonalMessage;
            SendDate = SentDate;
        }
        public void SavePersonalMessage()
        {
            File.AppendAllText(@"C:\Users\user\Desktop\PersonalMessages.txt" ,PersonalMessageId + " " + Sender.UserID + " " + SendDate + " " + PersonalMessageText + " " + Receiver.UserID);
        }
    }
}
