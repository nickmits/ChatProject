using System;
using System.Collections.Generic;
using System.Linq;
namespace Chat_Project
{
    internal class MainActions
    {
        private const string FORUM = "Forum", PERSONAL_MESSAGES = "Personal Messages",
            MANAGE_USERS = "Manage Users", LOGOUT = "Logout", EXIT = "Exit";

        public static IDataHandler DataProvider { get; set; }

        public MainActions(IDataHandler GivenDataProvider)
        {
            DataProvider = GivenDataProvider;
        }

        public string Showmenu(UserType TypeUser)
        {
            List<string> MainMenu = new List<string>
            {
                FORUM,
                LOGOUT,
                EXIT
            };

            if (TypeUser != UserType.Guest)
            {
                MainMenu.Insert(1, PERSONAL_MESSAGES);
                MainMenu.Insert(2, MANAGE_USERS);
            }

            return SelectMenu.Vertical(MainMenu).NameOfChoice;
        }

        public void MainMenu(User ActiveUser)
        {
            SpecificUserActions SpecificMenu = new SpecificUserActions();

            while (true)
            {
                switch (Showmenu(ActiveUser.TypeOfUser))
                {
                    case FORUM:
                        SpecificMenu.ShowForumMenu(DataProvider, ActiveUser);
                        break;
                    case PERSONAL_MESSAGES:
                        SpecificMenu.ShowPersonalMenu(ActiveUser, DataProvider);
                        break;
                    case MANAGE_USERS:
                        SpecificMenu.ShowManageUserMenu(ActiveUser, DataProvider);
                        break;

                    case LOGOUT:
                        return;
                    default:
                        Environment.Exit(0);
                        break;
                }
            }
        }

        public static User SelectUser()
        {
            List<User> UsersList = DataProvider.ReadUserData();
            List<string> UsernameList = UsersList.Select(UserInList => UserInList.Username).ToList();

            return UsersList[SelectMenu.Vertical(UsernameList).IndexOfChoice];
        }

        public static User AdminSelectsUser()
        {
            List<User> UsersList = DataProvider.ReadUserData();
            List<string> UsernameList = UsersList.Skip(1).Select(UserInList => UserInList.Username).ToList();

            return UsersList[SelectMenu.Vertical(UsernameList).IndexOfChoice];
        }
    }
}
