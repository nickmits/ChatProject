using System;
using System.Collections.Generic;
using System.Linq;

namespace Chat_Project
{
    internal class SignupOrLogin
    {
        private const string SIGN_UP = "SignUp", LOGGIN = "Login";
        public IDataHandler DataProvider;

        public SignupOrLogin(IDataHandler ChosenDataProvider)
        {
            DataProvider = ChosenDataProvider;
        }

        public User SignOrLog(IDataHandler DataProvider)
        {
            while (true)
            {

                string ChoiceIfUserSignUpOrLogin = SelectMenu.Horizontal(new List<string> { SIGN_UP, LOGGIN });

                if (ChoiceIfUserSignUpOrLogin == SIGN_UP)
                {
                    User ActiveUser = SignUpNewUser();
                    Console.WriteLine("Welcome user " + ActiveUser.Username + " and password " + ActiveUser.Password);
                    return ActiveUser;
                }
                else if (ChoiceIfUserSignUpOrLogin == LOGGIN)
                {
                    do
                    {
                        User ActiveUser = LoginUser();
                        if (ActiveUser == null)
                        {
                            Console.WriteLine("Invalid Username or Password, Please try again");
                        }
                        else
                        {
                            Console.WriteLine("You are in!!");
                            return ActiveUser;

                        }
                    }
                    while (true);
                }
                else
                {
                    Console.WriteLine("Wrong Choice, try again");
                }
            }

        }

        public User SignUpNewUser()
        {
            UserData Data = GetInputUserData(true);

            User NewUser = new User()
            {
                TypeOfUser = DataProvider.IsUsertableEmpty() ? UserType.Administrator : UserType.User,
                Username = Data.UserName,
                Password = Data.UserPassword

            };
            DataProvider.CreateUserData(NewUser);
            return NewUser;
        }

        public User LoginUser()
        {
            UserData Data = GetInputUserData(false);

            return DataProvider
                .ReadUserData()
                .SingleOrDefault(FoundUser => FoundUser.Username == Data.UserName && FoundUser.Password == Data.UserPassword);
        }

        internal struct UserData
        {
            internal string UserName;
            internal string UserPassword;
        }

        internal UserData GetInputUserData(bool ForSignUp)
        {
            UserData InputData = new UserData();
            Console.WriteLine("Username");
            InputData.UserName = InputUsername(ForSignUp);
            Console.WriteLine("Password");
            InputData.UserPassword = InputPassword();

            return InputData;
        }

        public string InputPassword()
        {
            while (true)
            {
                string Password = HidePassword();
                if (!IsCorrectLength(Password))
                {
                    Console.WriteLine("Input 5-20 characters");
                }
                else if (!PasswordHasNumbs(Password))
                {
                    Console.WriteLine("Password must contain Numbs");
                }
                else
                {
                    return Password;
                }
            }
        }
        private string HidePassword()
        {
            string pass = "";
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(true);
                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    pass += key.KeyChar;
                    Console.Write("*");
                }
                else if (key.Key == ConsoleKey.Backspace && pass.Length > 0)
                {
                    pass = pass.Substring(0, (pass.Length - 1));
                    Console.Write("\b \b");
                }
            } while (key.Key != ConsoleKey.Enter);
            return pass;
        }
        private bool IsCorrectLength(string pass)
        {
            return pass.Length > 5 && pass.Length < 20;
        }

        private bool PasswordHasNumbs(string password)
        {
            foreach (var character in password)
            {
                if (char.IsNumber(character))
                {
                    return true;
                }

            }
            return false;
        }


        public string InputUsername(bool ForSignUp)
        {
            while (true)
            {

                string Username = Console.ReadLine();
                if (!IsUsernameCorrectLength(Username))
                {
                    Console.WriteLine("Input 5-20 Char");
                }
                else if (!IsThereCharInput(Username))
                {
                    Console.WriteLine("Only letters accept");
                }
                else if (ForSignUp && DataProvider.UsernameExists(Username))
                {
                    Console.WriteLine("Username exists, try another");
                }
                else
                {

                    return Username;
                }

                Console.WriteLine("Wrong input, Try again");
            }

        }


        private bool IsUsernameCorrectLength(string input)
        {
            return input.Length > 5 && input.Length < 20;
        }

        private bool IsThereCharInput(string input)
        {
            foreach (var Character in input)
            {
                if (!Char.IsLetter(Character))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
