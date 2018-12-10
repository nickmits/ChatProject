using System;


namespace Chat_Project
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            while (true)
            {
                IDataHandler DataProvider = new DataHandingOnDatabase();
                MainActions MainMenuSelection = new MainActions(new DataHandingOnDatabase());
                Console.WriteLine("WELCOME");
                SignupOrLogin WelcomeScreen = new SignupOrLogin(DataProvider);
                User LoggedInUser = WelcomeScreen.SignOrLog(DataProvider);
                string ResultShowmenu = MainMenuSelection.Showmenu(LoggedInUser.TypeOfUser);
                
                Console.ReadKey();
            }


        }
    }
}
