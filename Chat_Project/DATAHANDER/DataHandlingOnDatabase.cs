﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;

namespace Chat_Project
{
    internal class DataHandlingOnDatabase : IDataHandler
    {
        public List<ForumMessage> ReadForumMessages()
        {
            using (ChatDatabase ChatDB = new ChatDatabase())
            {
                return ChatDB
                    .ForumMessages
                    .Include(FM => FM.Sender)
                    .ToList();
            }
        }

        public List<PersonalMessage> ReadPersonalMessages()
        {
            using (ChatDatabase ChatDB = new ChatDatabase())
            {
                return ChatDB
                    .PersonalMessages
                    .Include(PM => PM.Sender)
                    .ToList();
            }
        }

        public List<User> ReadUserData()
        {
            using (ChatDatabase ChatDB = new ChatDatabase())
            {
                return ChatDB.Users
                    .Include(u => u.ForumMessages)
                    .Include(u => u.ReceivedMessages)
                    .Include(u => u.SentMessages)
                    .ToList();
            }
        }


        public bool CreateForumMessageData(ForumMessage forumMessage)
        {
            using (ChatDatabase ChatDB = new ChatDatabase())
            {
                ChatDB.ForumMessages.Add(forumMessage);

                return SaveComitChanges(ChatDB);
            }
        }

        public bool CreatePersonalMessageData(PersonalMessage personal)
        {
            using (ChatDatabase ChatDB = new ChatDatabase())
            {
                ChatDB.PersonalMessages.Add(personal);

                return SaveComitChanges(ChatDB);
            }
        }

        public bool CreateUserData(User user)
        {
            using (ChatDatabase ChatDB = new ChatDatabase())
            {
                ChatDB.Users.Add(user);

                return SaveComitChanges(ChatDB);
            }
        }

        public bool SaveComitChanges(ChatDatabase chat)
        {
            try
            {
                return (chat.SaveChanges() > 0);
            }
            catch (Exception e)
            {
                Debug.Write(e.Message);
                return false;
            }
        }

        public bool UpdateForumMessage(ForumMessage OldForumMessage, string NewForumMessageText)
        {
            using (ChatDatabase ChatDB = new ChatDatabase())
            {
                ChatDB.ForumMessages.Single(fm =>
                fm.TextMessageToAll == OldForumMessage.TextMessageToAll).
                TextMessageToAll = NewForumMessageText;
                return SaveComitChanges(ChatDB);
            }
        }

        public bool UpdateUserName(User UpdatedUser, string NewUsername)
        {
            using (ChatDatabase ChatDB = new ChatDatabase())
            {
                ChatDB.Users.Single(ThisUser => ThisUser.Username == UpdatedUser.Username).
                    Username = NewUsername;
                return SaveComitChanges(ChatDB);
            }
        }

        public bool UpdateUserPassword(User UpdatedUser, string NewUserPassword)
        {
            using (ChatDatabase ChatDB = new ChatDatabase())
            {
                ChatDB.Users.Single(u => u.UserID == UpdatedUser.UserID).
                    Password = NewUserPassword;
                return SaveComitChanges(ChatDB);
            }
        }

        public bool UpdateUserAccess(User UpdatedUser)
        {
            using (ChatDatabase ChatDB = new ChatDatabase())
            {
                ChatDB.Users.Single(USER => USER.UserID == UpdatedUser.UserID).
                    TypeOfUser = UpdatedUser.TypeOfUser;
                return SaveComitChanges(ChatDB);
            }
        }

        public bool UpdatePersonalMessage(PersonalMessage OldPersonalMessage, string NewPersonalMessageText)
        {
            using (ChatDatabase ChatDB = new ChatDatabase())
            {
                ChatDB.PersonalMessages.Single(PM => 
                PM.PersonalMessageId == OldPersonalMessage.PersonalMessageId).
                PersonalMessageText = NewPersonalMessageText;
                return SaveComitChanges(ChatDB);
            }
        }

        public bool DeleteUser(User DeletedUser)
        {
            using (ChatDatabase ChatDB = new ChatDatabase())
            {
                User DeleteUser = ChatDB.Users.Single(u => u.UserID == DeletedUser.UserID);
                ChatDB.Users.Remove(DeleteUser);
                return SaveComitChanges(ChatDB);
            }
        }

        public bool DeletePersonalMessage(PersonalMessage DeletedMessage, User sender)
        {
            using (ChatDatabase ChatDB = new ChatDatabase())
            {
                PersonalMessage DeletePM = ChatDB.PersonalMessages.Single(pm =>
                pm.PersonalMessageId == DeletedMessage.PersonalMessageId);
                ChatDB.PersonalMessages.Remove(DeletePM);
                return SaveComitChanges(ChatDB);
            }
        }

        public bool DeleteForumMessage(ForumMessage DeletedMessage, User sender)
        {
            using (ChatDatabase ChatDB = new ChatDatabase())
            {
                ForumMessage DeletePM = ChatDB.ForumMessages.Single(fm =>
                fm.TextMessageToAll == DeletedMessage.TextMessageToAll);
                ChatDB.ForumMessages.Remove(DeletePM);

                return SaveComitChanges(ChatDB);
            }
        }

        public bool UsernameExists(string Username)
        {
            using (ChatDatabase ChatDB = new ChatDatabase())
            {
                return ChatDB.Users.Any(user => user.Username == Username);
            }
        }

        public bool IsUsertableEmpty()
        {
            using (ChatDatabase ChatDB = new ChatDatabase())
            {
                return !ChatDB.Users.Any();
            }
        }

        public bool MarkMessageAsRead(PersonalMessage ReadMessage)
        {
            using (ChatDatabase ChatDB = new ChatDatabase())
            {
                PersonalMessage ReadPM = ChatDB.PersonalMessages
                    .Single(rm => rm.PersonalMessageId == ReadMessage.PersonalMessageId);
                ReadPM.isRead = true;
                ReadPM.ReadDate = DateTime.Now;
                return SaveComitChanges(ChatDB);
            }
        }
    }
}
