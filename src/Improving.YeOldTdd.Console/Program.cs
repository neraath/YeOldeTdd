namespace Improving.YeOldeTdd
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            string menuOption = string.Empty;

            PrintTitle();
            PrintMenu();
            menuOption = Console.ReadLine();
            SelectFromMenu(menuOption);
        }

        /// <summary>
        /// Selects an action based on the printed menu.
        /// </summary>
        /// <param name="menuOption"></param>
        public static void SelectFromMenu(string menuOption)
        {
            if (string.IsNullOrEmpty(menuOption)) throw new ArgumentNullException("menuOption");

            switch (menuOption)
            {
                default:
                    throw new ArgumentException(string.Format("Unknown parameter value: {0}", menuOption), "menuOption");
            }
        }

        #region Private Methods

        /// <summary>
        /// Prints the title of the game.
        /// </summary>
        private static void PrintTitle()
        {
            Console.WriteLine("===== Welcome to Ye Olde Battleground =====");
        }

        /// <summary>
        /// Prints the menu.
        /// </summary>
        private static void PrintMenu()
        {
            Console.WriteLine("===========================================");
            Console.WriteLine("=====            Main Menu           ======");
            Console.WriteLine("=====                                ======");
            Console.WriteLine("=====  A. Go to War                  ======");
            Console.WriteLine("=====  Q. Quit Game                  ======");
            Console.WriteLine("=====                                ======");
            Console.WriteLine("===========================================");
        }

        #endregion
    }
}
