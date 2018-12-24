using System;

namespace Chat_Project
{
    internal class UpdateLoginCodes : Action
    {
        public UpdateLoginCodes(IDataHandler DataProvider, User ActiveUser) : base(DataProvider, ActiveUser) { }
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

                    return DataHandler.UpdateUserName(ActiveUser, NewUsername);
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

                    return DataHandler.UpdateUserPassword(ActiveUser, NewPassword);
                }
                else { Console.WriteLine("Wrong Password,Try Again"); }
            }
            while (true);

        }
    }
}
