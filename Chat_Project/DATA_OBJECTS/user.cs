using System.Collections.Generic;

namespace Chat_Project
{
    internal class User
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public UserType TypeOfUser { get; set; }

        public IList<ForumMessage> ForumMessages { get; set; }
        public IList<PersonalMessage> ReceivedMessages { get; set; }
        public IList<PersonalMessage> SentMessages { get; set; }

        public User()
        {

            ForumMessages = new List<ForumMessage>();
            ReceivedMessages = new List<PersonalMessage>();
            SentMessages = new List<PersonalMessage>();
        }
    }
}
