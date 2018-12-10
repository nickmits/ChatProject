using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_Project
{
    class SpecificUserActions
    {
        internal void ShowForumMenu(ForumMessage FM,string TextMessage,IDataHandler DataHandler, User ActiveUser,UserType TypeUser)
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

            ForumActions ForumAction = new ForumActions();
            MainActions MA = new MainActions(DataHandler);
            switch (UserSelection)
            {
                case "All Messages":
                    ForumAction.ShowAllMessages(ActiveUser);
                    break;
                case "My Messages":
                    ForumAction.ShowMyMessages(ActiveUser);
                    break;
                case "New Message":
                    ForumAction.CreateNewMessage(ActiveUser);
                    break;
                case "Edit Message":
                    ForumAction.EditMessage(FM,TextMessage,ActiveUser,DataHandler);
                    break;
                case "Delete Message":
                    ForumAction.DeleteMessage(FM, DataHandler,ActiveUser);
                    break;
                case "back":
                    MA.Showmenu(TypeUser);
                    break;
            }            
        }
        void ShowPersonalMenu(PersonalMessage PM,User ActiveUser, UserType TypeUser, IDataHandler dataHandler,string TextMessage)
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
            PersonalMessageActions PersonalMessageAction = new PersonalMessageActions();
            MainActions MA = new MainActions(dataHandler);
            switch (UserChoice)
            {
                case "Create Message":
                    PersonalMessageAction.CreateMessage(ActiveUser,dataHandler);
                    break;
                case "Show Received Messages":
                    PersonalMessageAction.ShowReceivedMessages(ActiveUser);
                    break;
                case "Show Sent Messages":
                    PersonalMessageAction.ShowSentMessages(ActiveUser);
                    break;
                case "Check If Message Read":
                    PersonalMessageAction.IsMessageRead(ActiveUser);
                    break;
                case "Edit Message":
                    PersonalMessageAction.UpdatePersonalMessage(PM, TextMessage, dataHandler);
                    break;
                case "Delete Message":
                    PersonalMessageAction.DeleteMessage(PM,dataHandler,ActiveUser);
                    break;
                case "back":
                    MA.Showmenu(TypeUser);
                    break;
            }
        }
        void ShowManageUserMenu(User ActiveUser, UserType TypeUser, IDataHandler dataHandler)
        {
            string AdminSelection = SelectMenu.Vertical(new List<string>
            {
                "Update User Access",
                "Delete User",
                "Back"
            });
            ManageUser MU = new ManageUser();
            MainActions MA = new MainActions(dataHandler);
            switch (AdminSelection)
            {
                case "Update UserAccess":
                   MU.UpdateUserAccess(ActiveUser,TypeUser,dataHandler);
                    break;
                case "Delete User":
                    MU.DeleteUser(dataHandler, ActiveUser);
                    break;
                case "back":
                    MA.Showmenu(TypeUser);
                    break;


            }
        }
        
    }
}
