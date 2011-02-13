namespace Improving.YeOldeTdd
{
    using System;

    using Improving.YeOldeTdd.Logic;
    using Improving.YeOldeTdd.Logic.Events;
    using Improving.YeOldeTdd.Model;
    using Improving.YeOldeTdd.Model.Entities;

    public class Program
    {
        public static void Main(string[] args)
        {
            string menuOption = string.Empty;

            while (menuOption != "Q")
            {
                PrintTitle();
                PrintMenu();
                menuOption = Console.ReadLine();
                SelectFromMenu(menuOption);
            }
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
                case "A":
                    var armyA = new Army();
                    var armyB = new Army();
                    var warLogic = new WarLogic();
                    warLogic.OnWarEnding += OnWarEnding;
                    warLogic.GoToWar(armyA, armyB);
                    break;
                case "Q":
                    Console.WriteLine("Quitting the game.");
                    break;
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

        private static void OnWarEnding(object sender, WarEndingEventArgs args)
        {
            Console.WriteLine("We have a victor! {0} is the winner of the war! Huzzah!", args.Victor);
        }

        #endregion
    }
}
