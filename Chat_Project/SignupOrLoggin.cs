using System;
using System.Collections.Generic;
using System.Linq;

namespace Chat_Project
{
    internal class SignupOrLogin
    {
        public IDataHandler DataProvider;

        public SignupOrLogin(IDataHandler ChosenDataProvider)
        {
            DataProvider = ChosenDataProvider;
        }
        public User SignOrLog(IDataHandler DataProvider)
        {
            while (true)
            {
                string ChoiceIfUserSignUpOrLogin = SelectMenu.Horizontal(new List<string> { "SignUp", "Login" });

                if (ChoiceIfUserSignUpOrLogin == "SignUp")
                {
                    User ActiveUser = SignUpNewUser();
                    Console.WriteLine("Welcome user " + ActiveUser.Username + " and password " + ActiveUser.Password);
                    return ActiveUser;
                }
                else if (ChoiceIfUserSignUpOrLogin == "Login")
                {
                    do
                    {
                        User ActiveUser = LoginUser();
                        if (ActiveUser == null)
                        {
                            Console.WriteLine("Invalid Username or Password,Please try again");
                        }
                        else
                        {
                            Console.WriteLine("You are in!!");
                            break;
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
            UserData Data = GetInputUserData();

            User NewUser = new User()
            {
                Username = Data.UserName,
                Password = Data.UserPassword,
                TypeOfUser = UserType.User
            };

            DataProvider.CreateUserData(NewUser);
            return NewUser;
        }

        public User LoginUser()
        {
            UserData Data = GetInputUserData();

            return DataProvider
                .ReadUserData()
                .SingleOrDefault(FoundUser => FoundUser.Username == Data.UserName && FoundUser.Password == Data.UserPassword);
        }

        internal struct UserData
        {
            internal string UserName;
            internal string UserPassword;
        }

        internal UserData GetInputUserData()
        {
            UserData InputData = new UserData();
            Console.WriteLine("Username");
            InputData.UserName = ReadUsername();
            Console.WriteLine("Password");
            InputData.UserPassword = InputPassword();

            return InputData;
        }

        public string InputPassword()
        {
            while (true)
            {
                string Password = Console.ReadLine();
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

        private static bool IsCorrectLength(string pass)
        {
            return pass.Length > 5 && pass.Length < 20;
        }

        private static bool PasswordHasNumbs(string password)
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


        public static string ReadUsername()
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
                else
                {
                    return Username;
                }

                Console.WriteLine("Wrong input, Try again");
            }

        }

        private static bool IsUsernameCorrectLength(string input)
        {
            return input.Length > 5 && input.Length < 20;
        }

        private static bool IsThereCharInput(string input)
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
