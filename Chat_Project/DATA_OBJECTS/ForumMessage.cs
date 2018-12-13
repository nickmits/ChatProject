using System;

namespace Chat_Project
{
    internal class ForumMessage
    {
        public User Sender { get; set; }
        public int ForumMessageId { get; set; }
        public int SenderId { get; set; }
        public string TextMessageToAll { get; set; }
        public DateTime SendDateToAll { get; set; }

        public ForumMessage()
        {
            SendDateToAll = DateTime.Now;
        }
    }
}
