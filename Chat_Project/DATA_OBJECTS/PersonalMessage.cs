using System;
using System.IO;
using System.Linq;

namespace Chat_Project
{
    internal class PersonalMessage
    {
        public User Sender { get; set; }
        public User Receiver { get; set; }
        public string PersonalMessageText { get; set; }
        internal bool isRead { get; set; }
        internal DateTime SendDate { get; set; }
        internal DateTime ReadDate { get; set; }
        public int PersonalMessageId { get; set; }
        public int SenderID { get; set; }
        public int ReceiverID { get; set; }

        public PersonalMessage()
        {
            SendDate = DateTime.Now;
            ReadDate = DateTime.Now;
            isRead = false;
        }

    }
}
