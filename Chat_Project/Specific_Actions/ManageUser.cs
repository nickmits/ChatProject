using System;
using System.Collections.Generic;

namespace Chat_Project
{
    internal class ManageUser
    {
        private IDataHandler DataProvider;
        private User ActiveUser;
        public ManageUser(IDataHandler DataHandler, User LogUser)
        {
            DataProvider = DataHandler;
            ActiveUser = LogUser;
        }

        public bool DeleteUser()
        {
            SpecificUserActions SUA = new SpecificUserActions();

            User SelectedUser = MainActions.AdminSelectsUser();

            string UpdateSelection = SelectMenu.Horizontal(new List<string>
            {
                "Delete User",
                "Back"
            });

            switch (UpdateSelection)
            {
                case "Delete User":
                default:
                    return DataProvider.DeleteUser(SelectedUser);
                case "Back":
                    return false;
            }
        }

        public bool UpdateUserAccess()
        {            
            string UpdateSelection = SelectMenu.Horizontal(new List<string>
            {
                "Upgrade",
                "Downgrade",
                "Back"
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
                    DataProvider.UpdateUserAccess(SelectedUser);
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
                    DataProvider.UpdateUserAccess(UserSelection);
                    break;
                case "Back":
                    return false;
            }
            return true;
        }
    }
}

