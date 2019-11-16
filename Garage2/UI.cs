using System;

namespace Garage2
{
    internal class UI
    {
        private GarageHandler GH { get; set; }
        public UI()
        {
            GH = new GarageHandler();
        }

        internal void run()
        {
            Console.WriteLine("Hi and welcome to the GarageHandler!");
            ShowMenu();
            string menuChoise = Console.ReadLine();

            switch (menuChoise)
            {
                case "0":
                    break;

                default:
                    break;
            }
        }

        private void ShowMenu()
        {
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("'0' for closing the menu");
        }

    }
}