using System;
using System.Collections.Generic;

namespace Chat_Project
{
    internal class ManageUser
    {
        private const string DELETE_USER = "Delete User", BACK = "Back", UPGRADE = "Upgrade",
            DOWNGRADE = "Downgrade", USER = "User", ADMIN = " Admin", GUEST = " Guest";
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
                DELETE_USER,
                BACK
            }).NameOfChoice;

            switch (UpdateSelection)
            {
                case DELETE_USER:
                default:
                    return DataProvider.DeleteUser(SelectedUser);
                case BACK:
                    return false;
            }
        }

        public bool UpdateUserAccess()
        {
            string UpdateSelection = SelectMenu.Horizontal(new List<string>
            {
                UPGRADE,
                DOWNGRADE,
                BACK
            }).NameOfChoice;

            switch (UpdateSelection)
            {
                case UPGRADE:

                    User SelectedUser = MainActions.SelectUser();
                    switch (SelectedUser.TypeOfUser)
                    {
                        case UserType.Guest:
                            Console.WriteLine("Upgrade to User or Admin;");
                            string AdminChoice = SelectMenu.Horizontal(new List<string> { USER, ADMIN }).NameOfChoice;

                            switch (AdminChoice)
                            {
                                case USER:
                                default:
                                    SelectedUser.TypeOfUser = UserType.User;
                                    break;
                                case ADMIN:
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
                case DOWNGRADE:
                    Console.WriteLine("Choose the user you want to Downgrade:");
                    User UserSelection = MainActions.SelectUser();
                    switch (UserSelection.TypeOfUser)
                    {
                        case UserType.Administrator:
                            Console.WriteLine("Downgrade to User or Guest;");
                            string AdminChoice = SelectMenu.Horizontal(new List<string> { USER, GUEST }).NameOfChoice;
                            switch (AdminChoice)
                            {
                                case USER:
                                default:
                                    UserSelection.TypeOfUser = UserType.User;
                                    break;
                                case GUEST:
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
                case BACK:
                    return false;
            }
            return true;
        }        
        public bool UpdateUsername()
        {
            do
            {
                Console.WriteLine("Type your old Username:");
                string OldUsername = Console.ReadLine();
                if (OldUsername == ActiveUser.Username)
                {
                    Console.WriteLine("Type New Username");
                    string NewUsername = Console.ReadLine();

                    return DataProvider.UpdateUserName(ActiveUser, NewUsername);
                }
                else { Console.WriteLine("Wrong Username,Try Again"); }
            }
            while (true);
        }

        public bool UpdatePassword()
        {
            do
            {
                Console.WriteLine("Type your old Password:");
                string OldPassword = Console.ReadLine();
                if (OldPassword == ActiveUser.Password)
                {
                    Console.WriteLine("Type New Password");
                    string NewPassword = Console.ReadLine();

                    return DataProvider.UpdateUserPassword(ActiveUser, NewPassword);
                }
                else { Console.WriteLine("Wrong Password,Try Again"); }
            }
            while (true);

        }
    }
}

