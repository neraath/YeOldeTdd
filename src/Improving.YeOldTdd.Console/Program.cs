namespace Improving.YeOldeTdd
{
    using System;

    using Improving.YeOldeTdd.Logic;
    using Improving.YeOldeTdd.Logic.Events;
    using Improving.YeOldeTdd.Model.Entities;

    public class Program
    {
        public static void Main(string[] args)
        {
            string menuOption = string.Empty;

            try
            {
                while (menuOption.ToUpperInvariant() != "Q")
                {
                    PrintTitle();
                    PrintMenu();
                    menuOption = Console.ReadLine();
                    SelectFromMenu(menuOption);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.ReadLine();
        }

        /// <summary>
        /// Selects an action based on the printed menu.
        /// </summary>
        /// <param name="menuOption"></param>
        public static void SelectFromMenu(string menuOption)
        {
            if (string.IsNullOrEmpty(menuOption)) throw new ArgumentNullException("menuOption");

            switch (menuOption.ToUpperInvariant())
            {
                case "A":
                    WarLogic logic = new WarLogic();
                    logic.OnWarEnding += PrintVictor;
                    //logic.GoToWar(new Army() { Power = 5 }, new Army() { Power = 5 });
                    logic.GoToWar(new Army(), new Army());
                    break;
                case "Q":
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

        private static void PrintVictor(object sender, WarEndingEventArgs args)
        {
            Console.WriteLine("Alas, the war has ended! {0} is our victor!", args.Victor.ToString());
        }

        #endregion
    }
}
