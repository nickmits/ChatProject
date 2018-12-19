using System.Collections.Generic;

namespace Chat_Project
{
    internal class SpecificUserActions
    {
        private const string ALL_MESSAGES = "All Messages", MY_MESSAGES = "My Messages", NEW_MESSAGE = "New Message", EDIT_MESSAGE = "Edit Message"
            , DELETE_MESSAGE = "Delete Message", BACK = "Back", CREATE_MESSAGE = "Create Message", SHOW_RECEIVED_MESSAGES = "Show Received Messages"
            , SHOW_SENT_MESSAGES = "Show Sent Messages", CHECK_IF_MESSAGE_READ = "Check If Message Read", UPDATE_USER_ACCESS = "Update User Access", DELETE_USER = "Delete User";
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
                case NEW_MESSAGE:
                    ForumAction.CreateMessage();
                    break;
                case EDIT_MESSAGE:
                    ForumAction.UpdateMessage();
                    break;
                case DELETE_MESSAGE:
                    ForumAction.DeleteMessage();
                    break;
                case BACK:
                    MA.Showmenu(ActiveUser.TypeOfUser);
                    break;
            }
        }
        internal void ShowPersonalMenu(User ActiveUser, IDataHandler dataHandler)
        {

            string UserChoice = SelectMenu.Horizontal(new List<string>
            {
                CREATE_MESSAGE,
                SHOW_RECEIVED_MESSAGES,
                SHOW_SENT_MESSAGES,
                CHECK_IF_MESSAGE_READ,
                EDIT_MESSAGE,
                DELETE_MESSAGE,
                BACK
            });
            PersonalMessageActions PersonalMessageAction = new PersonalMessageActions(dataHandler, ActiveUser);
            MainActions MA = new MainActions(dataHandler);
            switch (UserChoice)
            {
                case CREATE_MESSAGE:
                    PersonalMessageAction.CreateMessage();
                    break;
                case SHOW_RECEIVED_MESSAGES:
                    PersonalMessageAction.ShowReceivedMessages();
                    break;
                case SHOW_SENT_MESSAGES:
                    PersonalMessageAction.ShowSentMessages();
                    break;
                case CHECK_IF_MESSAGE_READ:
                    PersonalMessageAction.IsMessageRead();
                    break;
                case EDIT_MESSAGE:
                    PersonalMessageAction.UpdateMessage();
                    break;
                case DELETE_MESSAGE:
                    PersonalMessageAction.DeleteMessage();
                    break;
                case BACK:
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
                    UPDATE_USER_ACCESS,
                    DELETE_USER,
                    BACK
                });
                switch (AdminSelection)
                {
                    case UPDATE_USER_ACCESS:
                        MU.UpdateUserAccess();
                        break;
                    case DELETE_USER:
                        MU.DeleteUser();
                        break;
                    default:
                        return;
                }
            }
        }

    }
}
