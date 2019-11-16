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
            while (true)
            {
                Console.WriteLine("Hi and welcome to the GarageHandler!");
                ShowMenu();
                string menuChoise = Console.ReadLine();

                switch (menuChoise)
                {
                    case "0":
                        break;

                    case "1":
                        //create a Garage
                        string input11;
                        int input12;
                        Console.WriteLine("What is the name of the Garage?");
                        input11 = Console.ReadLine();
                        Console.WriteLine("What capacity should the Garage have?");
                        try
                        {
                            input12 = int.Parse(Console.ReadLine());
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Wrong format of the Capacity (not an integer).");
                            Console.WriteLine("Please try again");
                            Console.WriteLine();
                            continue;
                        }
                        GH.CreateGarage(input11, input12);


                        break;

                    default:
                        break;
                }
            }

           
        }

        private void ShowMenu()
        {
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("'0' to close the menu");
            Console.WriteLine("'1' to create a garage");
        }

    }
}