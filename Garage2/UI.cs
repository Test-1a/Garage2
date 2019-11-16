using System;
using System.Collections.Generic;

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
                        return;

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

                    case "2":
                        //Park a vehicle
                        int input2;
                        string whichVehicleToPark;
                        List<string> parkAnswers = new List<string>();
                        Console.WriteLine("What kind of vehicle do you want to park?");
                        Console.WriteLine("1: Car, 2: MC, 3: Bus, 4: Airplane, 5: Boat");
                        try
                        {
                            input2 = int.Parse(Console.ReadLine());
                        }
                        catch(FormatException)
                        {
                            Console.WriteLine("Wrong format of the Menuchoise (not an integer).");
                            Console.WriteLine("Please try again");
                            Console.WriteLine();
                            continue;
                        }
                        switch (input2)
                        {
                            case 1:
                                //Car
                                whichVehicleToPark = "Car";
                                break;

                            case 2:
                                //MC
                                whichVehicleToPark = "MC";
                                break;

                            case 3:
                                //Bus
                                whichVehicleToPark = "Bus";
                                break;

                            case 4:
                                //Airplane
                                whichVehicleToPark = "Airplane";
                                break;

                            case 5:
                                //Boat
                                whichVehicleToPark = "Boat";
                                break;

                            default:
                                Console.WriteLine("Please choose something in the list above");
                                continue;
                        }
                        parkAnswers.Add(whichVehicleToPark);
                        List<string> parkQuestions = GH.GetParkQuestions(whichVehicleToPark);

                        foreach (var question in parkQuestions)
                        {
                            Console.WriteLine(question);
                            parkAnswers.Add(Console.ReadLine());
                        }
                        bool parkingSuccessful = GH.ParkVehicle(parkAnswers);
                        break;

                    case "3":
                        //unpark a vehicle
                        Console.WriteLine("What is the RegNr for the vehicle to unpark?");
                        string input3 = Console.ReadLine().ToUpper();
                        GH.Unpark(input3);
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
            Console.WriteLine("'2' to park a vehicle");
            Console.WriteLine("'3' to unpark a vehicle");
        }

    }
}