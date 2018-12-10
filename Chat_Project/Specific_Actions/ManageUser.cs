using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_Project
{
    class ManageUser
    {
        
        
        public void DeleteUser(IDataHandler DataHandler, User SelectedUser)
        {
            Console.WriteLine("Delete this User;");
            DataHandler.DeleteUser(SelectedUser);
        }
        public bool UpdateUserAccess(User UpdatedUser, UserType NewUserAccess, IDataHandler DataProvider)
        {
            MainActions MA = new MainActions(DataProvider);
            string UpdateSelection = SelectMenu.Horizontal(new List<string>
            {
                "Upgrade",
                "Downgrade"
            });
            switch (UpdateSelection)
            {
                case "Upgrade":

                    User SelectedUser = MainActions.SelectUser();
                    switch (SelectedUser.TypeOfUser)
                    {
                        case UserType.Guest:
                            Console.WriteLine("Upgrade to User or Admin;");
                            string AdminChoice = SelectMenu.Horizontal(new List<string> { "User", " Admin" });
                            switch (AdminChoice)
                            {
                                case "User":
                                default:
                                    SelectedUser.TypeOfUser = UserType.User;
                                    break;
                                case " Admin":
                                    SelectedUser.TypeOfUser = UserType.Administrator;
                                    break;
                            }
                            break;
                        case UserType.User:
                            SelectedUser.TypeOfUser = UserType.Administrator;
                            break;
                        case UserType.Administrator:
                        default:
                            break;
                    }
                    DataProvider.UpdateUserAccess(SelectedUser,NewUserAccess);
                    break;
                case "Downgrade":

                    Console.WriteLine("Choose the user you want to Downgrade:");
                    User UserSelection = MainActions.SelectUser();
                    switch (UserSelection.TypeOfUser)
                    {
                        case UserType.Administrator:
                            Console.WriteLine("Downgrade to User or Guest;");
                            string AdminChoice = SelectMenu.Horizontal(new List<string> { "User", " Guest" });
                            switch (AdminChoice)
                            {
                                case "User":
                                default:
                                    UserSelection.TypeOfUser = UserType.User;
                                    break;
                                case " Guest":
                                    UserSelection.TypeOfUser = UserType.Guest;
                                    break;
                            }
                            break;
                        case UserType.User:
                            UserSelection.TypeOfUser = UserType.Guest;
                            break;
                        case UserType.Guest:
                        default:
                            break;
                    }
                    DataProvider.UpdateUserAccess(UserSelection,NewUserAccess);
                    break;
            }
            return true;
        }
    }
}

