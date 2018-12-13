using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Chat_Project
{
    internal class DataHandingOnFile : IDataHandler
    {
        public List<User> ReadUserData()
        {
            List<User> UserList = new List<User>();
            foreach (string line in File.ReadLines(@"C:\Users\user\Desktop\users.txt"))
            {
                string[] UserElements = line.Split(' ');
                UserList.Add(new User());

            }
            return UserList;
        }
        public List<ForumMessage> ReadForumMessages()
        {
            return File.ReadLines(@"C:\Users\user\Desktop\ForumMessages.txt").Select(EveryLine =>
            {
                 string[] UserElements = EveryLine.Split(' ');
                return new ForumMessage()
                 {
                     ForumMessageId = int.Parse(UserElements[0]),
                     SenderId= int.Parse(UserElements[1]),
                     SendDateToAll= DateTime.Parse(UserElements[2]),
                    TextMessageToAll = UserElements[3]
                };
                    
            }).ToList();
        }
        public List<PersonalMessage> ReadPersonalMessages()
        {
            return File.ReadLines(@"C:\Users\user\Desktop\PersonalMessages.txt").Select(EveryLine =>
           {
               string[] UserElements = EveryLine.Split(' ');
               return new PersonalMessage()
               {
                   PersonalMessageId = int.Parse(UserElements[0]),
                   SenderID = int.Parse(UserElements[1]),
                   SendDate = DateTime.Parse(UserElements[2]),
                   PersonalMessageText = UserElements[3],
                   ReceiverID = int.Parse(UserElements[4])
               };
           }).ToList();
        }
        public void SavePersonalMessage(PersonalMessage PM)
        {
            File.AppendAllText(@"C:\Users\user\Desktop\PersonalMessages.txt",
                $"{GetNewPersonalMessageID()} {PM.SenderID} {PM.SendDate} {PM.PersonalMessageText} {PM.ReceiverID}");
        }
        public void SaveForumMessage(ForumMessage FM)
        {
            File.AppendAllText(@"C:\Users\user\Desktop\PersonalMessages.txt",
                $"{GetNewPersonalMessageID()} {FM.SenderId} {FM.SendDateToAll} {FM.TextMessageToAll} ");
        }
        public bool CreateForumMessageData(ForumMessage forumMessage)
        {
            File.AppendAllText(@"C:\Users\user\Desktop\Forummessages.txt", forumMessage.ForumMessageId + " " + forumMessage.SendDateToAll + " " + forumMessage.Sender.UserID + " " + forumMessage.TextMessageToAll + " " + Environment.NewLine);
            return true;
        }
        public bool CreateUserData(User user)
        {
            File.AppendAllText(@"C:\Users\user\Desktop\users.txt", user.UserID + " " + user.Username + " " + user.Password + " " + (int)user.TypeOfUser + Environment.NewLine);
            return true;
        }
        public bool CreatePersonalMessageData(PersonalMessage personal)
        {
            File.AppendAllText(@"C:\Users\user\Desktop\PersonalMessages.txt", personal.PersonalMessageId + " " + personal.Sender.UserID + " " + personal.SendDate + " " + personal.PersonalMessageText + " " + personal.Receiver.UserID);
            return true;
        }

        public bool UpdateForumMessage(ForumMessage OldForumMessage, string NewForumMessageText)
        {

            List<string> AllLines = File.ReadLines(@"C:\Users\user\Desktop\ForumMessages.txt").ToList();
            int index = 0;
            foreach (string line in AllLines)
            {
                string[] ListElements = line.Split(' ');

                if (ListElements[2] == OldForumMessage.TextMessageToAll)
                {
                    index = AllLines.IndexOf(line);
                    AllLines[index] = NewForumMessageText;
                    break;
                }
                else
                {
                    index++;
                }
            }
            File.WriteAllLines(@"C:\Users\user\Desktop\ForumMessages.txt", AllLines);
            return true;
        }


        public bool UpdatePersonalMessage(PersonalMessage OldPersonalMessage, string NewPersonalMessageText)
        {
            List<string> AllLines = File.ReadLines(@"C:\Users\user\Desktop\PersonalMessages.txt").ToList();
            int index = 0;
            foreach (string line in AllLines)
            {
                string[] ListElements = line.Split(' ');

                if (ListElements[2] == OldPersonalMessage.PersonalMessageText)
                {
                    index = AllLines.IndexOf(line);
                    AllLines[index] = NewPersonalMessageText;
                    break;
                }
                else
                {
                    index++;
                }
            }
            File.WriteAllLines(@"C:\Users\user\Desktop\ForumMessages.txt", AllLines);
            return true;
        }


        public bool DeleteUser(User DeletedUser)
        {
            List<string> AllLines = File.ReadLines(@"C:\Users\user\Desktop\users.txt").ToList();
            int index = 0;
            foreach (string line in AllLines)
            {
                string[] ListElements = line.Split(' ');
                if (int.Parse(ListElements[0]) == DeletedUser.UserID)
                {
                    index = AllLines.IndexOf(line);
                    AllLines.RemoveAt(index);
                    break;
                }
                else
                {
                    index++;
                }
            }
            File.WriteAllLines(@"C:\Users\user\Desktop\users.txt", AllLines);
            return true;

        }

        public bool DeletePersonalMessage(PersonalMessage DeletedMessage, User sender)
        {

            List<string> AllLines = File.ReadLines(@"C:\Users\user\Desktop\PersonalMessages.txt").ToList();
            int index = 0;
            foreach (string line in AllLines)
            {
                string[] ListElements = line.Split(' ');

                if (ListElements[2] == DeletedMessage.PersonalMessageText)
                {
                    index = AllLines.IndexOf(line);
                    AllLines.RemoveAt(index);
                    break;
                }
                else
                {
                    index++;
                }
            }
            File.WriteAllLines(@"C:\Users\user\Desktop\ForumMessages.txt", AllLines);
            return true;
        }
        public bool DeleteForumMessage(ForumMessage SelectedMessage, User sender)
        {
            List<string> AllLines = File.ReadLines(@"C:\Users\user\Desktop\ForumMessages.txt").ToList();
            int index = 0;
            foreach (string line in AllLines)
            {
                string[] ListElements = line.Split(' ');
                if (ListElements[2] == SelectedMessage.TextMessageToAll)
                {
                    index = AllLines.IndexOf(line);
                    AllLines.RemoveAt(index);
                    break;
                }
                else
                {
                    index++;
                }
            }
            File.WriteAllLines(@"C:\Users\user\Desktop\ForumMessages.txt", AllLines);
            return true;
        }

        public bool UpdateUserAccess(User UpdatedUser)
        {
            List<string> AllLines = File.ReadLines(@"C:\Users\user\Desktop\users.txt").ToList();
            int index = 0;
            foreach (string line in AllLines)
            {
                string[] ListElements = line.Split(' ');
                if (int.Parse(ListElements[0]) == UpdatedUser.UserID)
                {
                    index = AllLines.IndexOf(line);
                    AllLines[index] = UpdatedUser.TypeOfUser.ToString();
                    break;
                }
                else
                {
                    index++;
                }
            }
            File.WriteAllLines(@"C:\Users\user\Desktop\users.txt", AllLines);
            return true;
        }

        public int GetNewForumMessageID()
        {
            return ReadForumMessages().LastOrDefault().ForumMessageId + 1;
        }

        public int GetNewPersonalMessageID()
        {
            return ReadPersonalMessages().LastOrDefault().PersonalMessageId + 1;
        }
    }
}
