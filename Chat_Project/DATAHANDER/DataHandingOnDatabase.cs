using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_Project
{
    class DataHandingOnDatabase:IDataHandler
    {
       

        public List<ForumMessage> ReadForumMessages()
        {
            using (ChatDatabase ChatDB = new ChatDatabase())
            {
                return ChatDB.ForumMessages.ToList();
            }
        }

        public List<PersonalMessage> ReadPersonalMessages()
        {
            using(ChatDatabase ChatDB = new ChatDatabase())
            {
                return ChatDB.PersonalMessages.ToList();
            }
        }

        public List<User> ReadUserData()
        {
            using (ChatDatabase ChatDB = new ChatDatabase())
            {
                return ChatDB.Users.ToList();
            }
        }

      
        public bool CreateForumMessageData(ForumMessage forumMessage)
        {
            using (ChatDatabase ChatDB = new ChatDatabase())
            {
                ChatDB.ForumMessages.Add(forumMessage);
                return SaveComitChanges();
            }
        }

        public bool CreatePersonalMessageData(PersonalMessage personal)
        {
            using (ChatDatabase ChatDB = new ChatDatabase())
            {
                ChatDB.PersonalMessages.Add(personal);
                SaveComitChanges();
            }
            return true;
        }

        public bool CreateUserData(User user)
        {
            using (ChatDatabase ChatDB = new ChatDatabase())
            {
                ChatDB.Users.Add(user);
                return SaveComitChanges();
            }
        }

        public bool SaveComitChanges()
        {
            using (ChatDatabase ChatDB = new ChatDatabase())
            {
                try
                {
                    return (ChatDB.SaveChanges() > 0);

                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }

        public bool UpdateForumMessage(ForumMessage OldForumMessage, string NewForumMessageText,User sender)
        {
            using (ChatDatabase ChatDB = new ChatDatabase())
            {
                ChatDB.ForumMessages.Single(fm => fm.TextMessageToAll == OldForumMessage.TextMessageToAll).TextMessageToAll = NewForumMessageText;
                return SaveComitChanges();
            }
        }

        public bool UpdateUserName(User UpdatedUser, string NewUsername)
        {
            using (ChatDatabase ChatDB = new ChatDatabase())
            {
                ChatDB.Users.Single(ThisUser => ThisUser.Username == UpdatedUser.Username).Username = NewUsername;
                return SaveComitChanges();
            }
        }

        public bool UpdateUserPassword(User UpdatedUser, string NewUserPassword)
        {
            using (ChatDatabase ChatDB = new ChatDatabase())
            {
                ChatDB.Users.Single(u => u.UserID == UpdatedUser.UserID).Password = NewUserPassword;
                return SaveComitChanges();
            }
        }

        public bool UpdateUserAccess(User UpdatedUser, UserType NewUserAccess)
        {
            using (ChatDatabase chatDB=new ChatDatabase())
            {
                chatDB.Users.Single(USER => USER.TypeOfUser == UpdatedUser.TypeOfUser).TypeOfUser = NewUserAccess;
                return SaveComitChanges();
            }
        }

        public bool UpdatePersonalMessage(PersonalMessage OldPersonalMessage, string NewPersonalMessageText)
        {
            using (ChatDatabase chatDB = new ChatDatabase())
            {
                chatDB.PersonalMessages.Single(PM => PM.PersonalMessageText == OldPersonalMessage.PersonalMessageText).PersonalMessageText = NewPersonalMessageText;
                return SaveComitChanges();
            }
        }

        public bool DeleteUser(User DeletedUser)
        {
            using (ChatDatabase ChatDB = new ChatDatabase())
            {
                User DeleteUser = ChatDB.Users.Single(u => u.UserID == DeletedUser.UserID);
                ChatDB.Users.Remove(DeleteUser);
                return SaveComitChanges();
            }
        }

        public bool DeletePersonalMessage(PersonalMessage DeletedMessage,User sender)
        {
            using (ChatDatabase ChatDB = new ChatDatabase())
            {
                PersonalMessage DeletePM = ChatDB.PersonalMessages.Single(pm =>pm.PersonalMessageText == DeletedMessage.PersonalMessageText);
                ChatDB.PersonalMessages.Remove(DeletePM);
                return SaveComitChanges();
            }
        }

        public bool DeleteForumMessage(ForumMessage DeletedMessage,User sender)
        {
            using (ChatDatabase ChatDB = new ChatDatabase())
            {
                ForumMessage DeletePM = ChatDB.ForumMessages.Single(fm => fm.TextMessageToAll == DeletedMessage.TextMessageToAll);
                ChatDB.ForumMessages.Remove(DeletePM);
                return SaveComitChanges();
            }
        }

    }
}
