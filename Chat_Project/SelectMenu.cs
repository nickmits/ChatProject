using System;
using System.Collections.Generic;


namespace Chat_Project
{

    public struct UserChoice
    {
        public string NameOfChoice;
        public int IndexOfChoice;
    }

    internal class SelectMenu
    {

        public static UserChoice Vertical(List<string> MenutoshowVertical)
        {
            int Selectedoption = 0;
            ConsoleKeyInfo UserChoice;
            do
            {
                Console.Clear();
                for (int option = 0; option < MenutoshowVertical.Count; option++)
                {
                    Console.ForegroundColor = (option == Selectedoption) ? ConsoleColor.Red : ConsoleColor.White;
                    Console.WriteLine(MenutoshowVertical[option]);
                }
                UserChoice = Console.ReadKey();

                if (UserChoice.Key == ConsoleKey.UpArrow)
                {
                    if (Selectedoption == 0) { Selectedoption = MenutoshowVertical.Count - 1; }
                    else { Selectedoption--; }
                }
                else if (UserChoice.Key == ConsoleKey.DownArrow)
                {
                    if (Selectedoption == MenutoshowVertical.Count - 1) { Selectedoption = 0; }
                    else { Selectedoption++; }
                }
            }
            while (UserChoice.Key != ConsoleKey.Enter);

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;

            return new UserChoice()
            {
                NameOfChoice = MenutoshowVertical[Selectedoption],
                IndexOfChoice = Selectedoption
            };
        }

        public static UserChoice Horizontal(List<string> MenuToShowHorizontal)
        {
            int CurrentOption = 0;
            ConsoleKeyInfo UserKeyPressed;
            do
            {
                Console.Clear();
                for (int option = 0; option < MenuToShowHorizontal.Count; option++)
                {
                    Console.ForegroundColor = (option == CurrentOption) ? ConsoleColor.Blue : ConsoleColor.White;
                    Console.Write(MenuToShowHorizontal[option] + "\t");
                }
                UserKeyPressed = Console.ReadKey();

                if (UserKeyPressed.Key == ConsoleKey.LeftArrow)
                {
                    if (CurrentOption == 0) { CurrentOption = MenuToShowHorizontal.Count - 1; }
                    else { CurrentOption--; }
                }
                else if (UserKeyPressed.Key == ConsoleKey.RightArrow)
                {
                    if (CurrentOption == MenuToShowHorizontal.Count - 1) { CurrentOption = 0; }
                    else { CurrentOption++; }
                }
            }
            while (UserKeyPressed.Key != ConsoleKey.Enter);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;

            return new UserChoice()
            {
                NameOfChoice = MenuToShowHorizontal[CurrentOption],
                IndexOfChoice = CurrentOption
            };
        }
    }
}
