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
            List<string> Adminmenu = new List<string> { "Chat", "Private Chat", "ManageUser", " Delete User", " Create Team", " Block Guest", " exit" };
            List<string> Usermenu = new List<string> { "Chat", "Private Chat", " exit" };
            List<string> Guestmenu = new List<string> { "Chat", " exit" };
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
            SpecificUserActions SpecificManu = new SpecificUserActions();
            switch (Showmenu(ActiveUser.TypeOfUser))
            {
                case "Forum":
                    SpecificManu.ShowForumMenu()
            }
        }

        
        public static User SelectUser()
        {
            List<User> UsersList = DataProvider.ReadUserData();
            List<string> UsernameList = UsersList.Select(UserInList => UserInList.Username).ToList();
            string SelectedUsername = SelectMenu.Vertical(UsernameList);
            return UsersList.Single(UserOfList => SelectedUsername == UserOfList.Username);
        }
        
      
    }
}
