using System.Collections.Generic;

namespace Chat_Project
{
    internal class SpecificUserActions
    {
        const string ALL_MESSAGES = "All Messages", MY_MESSAGES = "My Messages", NEW_MESSAGE = "New Message", EDIT_MESSAGE = "Edit Message", DELETE_MESSAGE = "Delete Message", BACK = "Back";
        internal void ShowForumMenu(IDataHandler DataHandler, User ActiveUser)
        {
            string UserSelection = SelectMenu.Horizontal(new List<string>
            {
                ALL_MESSAGES,
                MY_MESSAGES,
                NEW_MESSAGE,
                EDIT_MESSAGE,
                DELETE_MESSAGE,
                BACK
            });

            ForumActions ForumAction = new ForumActions(DataHandler, ActiveUser);
            MainActions MA = new MainActions(DataHandler);
            switch (UserSelection)
            {
                case ALL_MESSAGES:
                    ForumAction.ShowAllMessages();
                    break;
                case MY_MESSAGES:
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

            string UserChoice = SelectMenu.Horizontal(new List<string>
            {
                "Create Message",
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
            ManageUser MU = new ManageUser(dataHandler, ActiveUser);
            while (true)
            {
                string AdminSelection = SelectMenu.Vertical(new List<string>
                {
                    "Update User Access",
                    "Delete User",
                    "Back"
                });
                switch (AdminSelection)
                {
                    case "Update User Access":
                        MU.UpdateUserAccess();
                        break;
                    case "Delete User":
                        MU.DeleteUser();
                        break;
                    default:
                        return;
                }
            }
        }

    }
}
