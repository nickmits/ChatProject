using System;
using System.Collections.Generic;
using System.Linq;


namespace Chat_Project
{
    internal class SelectMenu
    {
        public static string Vertical(List<string> MenutoshowVertical)
        {
            int Selectedoption = 0;
            ConsoleKeyInfo UserChoice;
            do
            {
                Console.Clear();
                for (int option = 0; option < MenutoshowVertical.Count; option++)
                {
                    if (option == Selectedoption) { Console.ForegroundColor = ConsoleColor.Red; }

                    else { Console.ForegroundColor = ConsoleColor.White; }
                    Console.WriteLine(MenutoshowVertical[option]);
                }
                UserChoice = Console.ReadKey();

                if (UserChoice.Key == ConsoleKey.UpArrow)
                {
                    if (Selectedoption == 0) { Selectedoption = MenutoshowVertical.Count - 1; }
                    else { Selectedoption--; }
                }
                if (UserChoice.Key == ConsoleKey.DownArrow)
                {
                    if (Selectedoption == MenutoshowVertical.Count - 1) { Selectedoption = 0; }
                    else { Selectedoption++; }
                }

            }
            while (UserChoice.Key != ConsoleKey.Enter);
            string ResultSelectOption = MenutoshowVertical[Selectedoption];

            return ResultSelectOption;
        }

        public static string Horizontal(List<string> MenuToShowHorizontal)
        {
            int CurrentOption = 0;
            ConsoleKeyInfo UserKeyPressed;
            do
            {
                Console.Clear();
                for (int option = 0; option < MenuToShowHorizontal.Count; option++)
                {
                    if (option == CurrentOption) { Console.ForegroundColor = ConsoleColor.Blue; }
                    else { Console.ForegroundColor = ConsoleColor.White; }
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
            return MenuToShowHorizontal[CurrentOption];
        }

        



    }
}
