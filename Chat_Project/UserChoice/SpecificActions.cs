using System.Collections.Generic;

namespace Chat_Project
{
    internal class SpecificUserActions
    {
        internal void ShowForumMenu(IDataHandler DataHandler, User ActiveUser)
        {
            string UserSelection = SelectMenu.Horizontal(new List<string>
            {
                "All Messages",
                "My Messages",
                "New Message",
                "Edit Message",
                "Delete Message",
                "Back"
            });

            ForumActions ForumAction = new ForumActions(DataHandler,ActiveUser);
            MainActions MA = new MainActions(DataHandler);
            switch (UserSelection)
            {
                case "All Messages":
                    ForumAction.ShowAllMessages();
                    break;
                case "My Messages":
                    ForumAction.ShowMyMessages();
                    break;
                case "New Message":
                    ForumAction.CreateMessage();
                    break;
                case "Edit Message":
                    ForumAction.UpdateMessage();
                    break;
                case "Delete Message":
                    ForumAction.DeleteMessage();
                    break;
                case "back":
                    MA.Showmenu(ActiveUser.TypeOfUser);
                    break;
            }
        }
        internal void ShowPersonalMenu(User ActiveUser, IDataHandler dataHandler)
        {

            string UserChoice = SelectMenu.Vertical(new List<string>
            {
                "Create  Message",
                "Show Received Messages",
                "Show Sent Messages",
                "Check If Message Read",
                "Edit Message",
                "Delete Message",
                "Back"
            });
            PersonalMessageActions PersonalMessageAction = new PersonalMessageActions(dataHandler, ActiveUser);
            MainActions MA = new MainActions(dataHandler);
            switch (UserChoice)
            {
                case "Create Message":
                    PersonalMessageAction.CreateMessage();
                    break;
                case "Show Received Messages":
                    PersonalMessageAction.ShowReceivedMessages();
                    break;
                case "Show Sent Messages":
                    PersonalMessageAction.ShowSentMessages();
                    break;
                case "Check If Message Read":
                    PersonalMessageAction.IsMessageRead();
                    break;
                case "Edit Message":
                    PersonalMessageAction.UpdateMessage();
                    break;
                case "Delete Message":
                    PersonalMessageAction.DeleteMessage();
                    break; 
                case "back":
                    MA.Showmenu(ActiveUser.TypeOfUser);
                    break;
            }
        }
        internal void ShowManageUserMenu(User ActiveUser, IDataHandler dataHandler)
        {
            string AdminSelection = SelectMenu.Vertical(new List<string>
            {
                "Update User Access",
                "Delete User",
                "Back"
            });
            ManageUser MU = new ManageUser(dataHandler,ActiveUser);

            while (true)
            {
                switch (AdminSelection)
                {
                    case "Update UserAccess":
                        MU.UpdateUserAccess();
                        break;
                    case "Delete User":
                        MU.DeleteUser();
                        break;
                    case "back":
                        return;
                }
            }
        }

    }
}
