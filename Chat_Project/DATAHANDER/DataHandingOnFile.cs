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
                 return new ForumMessage(int.Parse(UserElements[0]), int.Parse(UserElements[1]), UserElements[2], DateTime.Parse(UserElements[3]));
             }).ToList();

        }

        public List<PersonalMessage> ReadPersonalMessages()
        {
            return File.ReadLines(@"C:\Users\user\Desktop\PersonalMessages.txt").Select(EveryLine =>
           {
               string[] UserElements = EveryLine.Split(' ');
               return new PersonalMessage(int.Parse(UserElements[0]), int.Parse(UserElements[1]), UserElements[2], DateTime.Parse(UserElements[3]));
           }).ToList();
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

        public bool UpdateForumMessage(ForumMessage OldForumMessage, string NewForumMessageText, User sender)
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
            Console.WriteLine("Are you sure to delete this User;");
            List<string> YesOrNo = new List<string> { "Yes", " No" };
            string YesNo = SelectMenu.Horizontal(YesOrNo);
            switch (YesNo)
            {
                case "Yes":
                    User SelectedUser = MainActions.SelectUser();
                    List<string> AllLines = File.ReadLines(@"C:\Users\user\Desktop\users.txt").ToList();
                    int index = 0;
                    foreach (string line in AllLines)
                    {
                        string[] ListElements = line.Split(' ');
                        if (int.Parse(ListElements[0]) == SelectedUser.UserID)
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
                case "No":
                default:
                    return false;
            }
        }

        public bool DeletePersonalMessage(PersonalMessage DeletedMessage, User sender)
        {
            PersonalMessageActions PMA = new PersonalMessageActions();
            Console.WriteLine("Are you sure to delete this message;");
            List<string> YesOrNo = new List<string> { "Yes", " No" };
            string YesNo = SelectMenu.Horizontal(YesOrNo);
            switch (YesNo)
            {
                case "Yes":
                    List<PersonalMessage> SentPersonalMessages = PMA.GetSentMessages(sender);
                    List<string> SentMessages = SentPersonalMessages
                        .Select(PersonalMessage => PersonalMessage.PersonalMessageText)
                        .ToList();
                    string SelectedMessageText = SelectMenu.Vertical(SentMessages);

                    PersonalMessage SelectedMessage = SentPersonalMessages
                        .Single(Message => Message.PersonalMessageText == SelectedMessageText);
                    List<string> AllLines = File.ReadLines(@"C:\Users\user\Desktop\PersonalMessages.txt").ToList();
                    int index = 0;
                    foreach (string line in AllLines)
                    {
                        string[] ListElements = line.Split(' ');

                        if (ListElements[2] == SelectedMessageText)
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
                case " No":
                default:
                    return false;
            }
        }


        public bool DeleteForumMessage(ForumMessage DeletedMessage, User sender)
        {
            ForumActions FA = new ForumActions();
            List<string> YesOrNo = new List<string> { "Yes", "No" };
            string YesNo = SelectMenu.Horizontal(YesOrNo);
            switch (YesNo)
            {
                case "Yes":
                    string TextMessage = SelectMenu.Vertical(FA.GetMyMessages(sender).
                Select(Messages => Messages.TextMessageToAll).ToList());
                    ForumMessage MessageToDelete = FA.GetMyMessages(sender)
                        .Single(MessageTextToDelete => MessageTextToDelete.TextMessageToAll == TextMessage);
                    List<string> AllLines = File.ReadLines(@"C:\Users\user\Desktop\ForumMessages.txt").ToList();
                    int index = 0;
                    foreach (string line in AllLines)
                    {
                        string[] ListElements = line.Split(' ');

                        if (ListElements[2] == TextMessage)
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
                case "No":
                default:
                    return false;
            }
        }        
        

        public bool UpdateUserAccess(User UpdatedUser,UserType userType)
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
    }
}
