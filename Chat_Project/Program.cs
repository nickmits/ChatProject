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
                MainActions MainMenuSelection = new MainActions(DataProvider);
                Console.WriteLine("WELCOME");
                SignupOrLogin WelcomeScreen = new SignupOrLogin(DataProvider);
                User LoggedInUser = WelcomeScreen.SignOrLog(DataProvider);
                MainMenuSelection.MainMenu(LoggedInUser);
            }


        }
    }
}
