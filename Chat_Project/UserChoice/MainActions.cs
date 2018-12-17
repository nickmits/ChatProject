using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Chat_Project
{
    internal class MainActions
    {
        public static IDataHandler DataProvider { get; set; }

        public MainActions(IDataHandler GivenDataProvider)
        {
            DataProvider = GivenDataProvider;
        }
        public string Showmenu(UserType TypeUser)
        {
            List<string> Adminmenu = new List<string> { "Forum", "Personal Messages", "Manage Users","Logout"," exit" };
            List<string> Usermenu = new List<string> { "Forum", "Personal Messages", "Logout", " exit" };
            List<string> Guestmenu = new List<string> { "Forum", "Logout"," exit" };
            switch (TypeUser)
            {
                case UserType.Administrator:
                    return SelectMenu.Vertical(Adminmenu);
                case UserType.User:
                default:
                    return SelectMenu.Vertical(Usermenu);
                case UserType.Guest:
                    return SelectMenu.Vertical(Guestmenu);
            }
        }
        public void MainMenu(User ActiveUser)
        {
            SpecificUserActions SpecificMenu = new SpecificUserActions();
            while (true)
            {
                switch (Showmenu(ActiveUser.TypeOfUser))
                {
                    case "Forum":
                        SpecificMenu.ShowForumMenu(DataProvider, ActiveUser);
                        break;
                    case "Personal Messages":
                        SpecificMenu.ShowPersonalMenu(ActiveUser, DataProvider);
                        break;
                    case "Manage Users":
                        SpecificMenu.ShowManageUserMenu(ActiveUser, DataProvider);
                        break;
                    case "Logout":
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
            string SelectedUsername = SelectMenu.Vertical(UsernameList);
            return UsersList.Single(UserOfList => SelectedUsername == UserOfList.Username);
        }
        public static User AdminSelectsUser()
        {
            List<User> UsersList = DataProvider.ReadUserData();
            List<string> UsernameList = UsersList.Skip(1).Select(UserInList => UserInList.Username).ToList();
            string SelectedUsername = SelectMenu.Vertical(UsernameList);
            return UsersList.Single(UserOfList => SelectedUsername == UserOfList.Username);
        }
      
    }
}
