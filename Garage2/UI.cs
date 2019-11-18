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
                        if (parkingSuccessful) Console.WriteLine("The parking was successful.");
                        else Console.WriteLine("Sorry, the garage was full.");
                        break;

                    case "3":
                        //unpark a vehicle
                        Console.WriteLine("What is the RegNr for the vehicle to unpark?");
                        string input3 = Console.ReadLine().ToUpper();
                        bool success = GH.Unpark(input3);
                        if (success) Console.WriteLine("The unparking was successful");
                        else Console.WriteLine("That vehicle was not parked in the garage");
                        break;

                    case "4":
                        //list all parked vehicles
                       Vehicle[] ves = GH.ListAllParkedVehicles();
                        ListVehicles(ves);
                        //for (int i = 0; i < ves.Length; i++)
                        //{
                        //    Vehicle item = ves[i];

                        //    if (item is Car castItem)
                        //    {
                        //        Console.WriteLine("It Is a CAR!!");
                        //        Console.WriteLine($"RegNr: {castItem.RegNr}");
                        //        Console.WriteLine($"Color: {castItem.Color}");
                        //        Console.WriteLine($"Antal hjul: {castItem.NumberOfWheels}");
                        //        Console.WriteLine($"Fueltype: {castItem.Fueltype}");
                        //    }
                        //    else if (item is MC castItem2)
                        //    {
                        //        Console.WriteLine("It Is a MC!!");
                        //        Console.WriteLine($"RegNr: {castItem2.RegNr}");
                        //        Console.WriteLine($"Color: {castItem2.Color}");
                        //        Console.WriteLine($"Antal hjul: {castItem2.NumberOfWheels}");
                        //        Console.WriteLine($"Cylinder Volume: {castItem2.CylinderVolume}");
                        //    }
                        //    else if (item is Bus castItem3)
                        //    {
                        //        Console.WriteLine("It Is a Bus!!");
                        //        Console.WriteLine($"RegNr: {castItem3.RegNr}");
                        //        Console.WriteLine($"Color: {castItem3.Color}");
                        //        Console.WriteLine($"Antal hjul: {castItem3.NumberOfWheels}");
                        //        Console.WriteLine($"Number of seats: {castItem3.NumberOfSeats}");
                        //    }
                        //    else if (item is Airplane castItem4)
                        //    {
                        //        Console.WriteLine("It Is an Airplane!!");
                        //        Console.WriteLine($"RegNr: {castItem4.RegNr}");
                        //        Console.WriteLine($"Color: {castItem4.Color}");
                        //        Console.WriteLine($"Antal hjul: {castItem4.NumberOfWheels}");
                        //        Console.WriteLine($"Number of engines: {castItem4.NumberOfEngines}");
                        //    }
                        //    else if (item is Boat castItem5)
                        //    {
                        //        Console.WriteLine("It Is a Boat!!");
                        //        Console.WriteLine($"RegNr: {castItem5.RegNr}");
                        //        Console.WriteLine($"Color: {castItem5.Color}");
                        //        Console.WriteLine($"Antal hjul: {castItem5.NumberOfWheels}");
                        //        Console.WriteLine($"Length: {castItem5.Length}");
                        //    }
                        //    else break;
                        //}
                        break;

                    case "5":
                        //list all parked vehicles and how many of each kind
                        Vehicle[] ves2 = GH.ListAllParkedVehicles();
                        ListVehicles(ves2);
                        /*var returned =*/ GH.ListNumberOfEachType();
                        break;

                    case "6":
                        //change the maximum capacity
                        int input6;
                        Console.WriteLine("How many vehicles should the maximum capacity be changed to?");
                        try 
                        {
                            input6 = int.Parse(Console.ReadLine()); 
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Wrong format of the Capacity (not an integer).");
                            Console.WriteLine("Please try again");
                            Console.WriteLine();
                            continue;
                        }
                        string answerBack = GH.ChangeMaximumCapacity(input6);
                        Console.WriteLine(answerBack);
                        break;

                    case "7":
                        //search for a vehicle by its regnr
                        string input7;
                        Console.WriteLine("What is the Reg Nr to search for?");
                        try
                        {
                            input7 = Console.ReadLine();
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Wrong format of the RegNr.");
                            Console.WriteLine("Please try again");
                            Console.WriteLine();
                            continue;
                        }
                        if(input7 == "")
                        {
                            Console.WriteLine("Please state a regNr (3 letters + 3 dights)");
                            continue;
                        }
                        Vehicle[] vss = GH.FindVehicleByRegNr(input7.ToUpper());
                        ListVehicles(vss);
                        break;

                    case "8":
                        //search for a vehicle by its color/numberOfWheels

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
            Console.WriteLine("'4' to list all parked vehicles");
            Console.WriteLine("'5' to list all parked vehicles and how many of each kind");
            Console.WriteLine("'6' to change the maximum capacity");
            Console.WriteLine("'7' to search a vehicle by its RegNr");
            Console.WriteLine("'8' to search a vehicle by its color/numberOfWheels");

        }

        private void ListVehicles(Vehicle[] ves)
        {
            for (int i = 0; i < ves.Length; i++)
            {
                Vehicle item = ves[i];

                if (item is Car castItem)
                {
                    Console.WriteLine("It Is a CAR!!");
                    Console.WriteLine($"RegNr: {castItem.RegNr}");
                    Console.WriteLine($"Color: {castItem.Color}");
                    Console.WriteLine($"Antal hjul: {castItem.NumberOfWheels}");
                    Console.WriteLine($"Fueltype: {castItem.Fueltype}");
                }
                else if (item is MC castItem2)
                {
                    Console.WriteLine("It Is a MC!!");
                    Console.WriteLine($"RegNr: {castItem2.RegNr}");
                    Console.WriteLine($"Color: {castItem2.Color}");
                    Console.WriteLine($"Antal hjul: {castItem2.NumberOfWheels}");
                    Console.WriteLine($"Cylinder Volume: {castItem2.CylinderVolume}");
                }
                else if (item is Bus castItem3)
                {
                    Console.WriteLine("It Is a Bus!!");
                    Console.WriteLine($"RegNr: {castItem3.RegNr}");
                    Console.WriteLine($"Color: {castItem3.Color}");
                    Console.WriteLine($"Antal hjul: {castItem3.NumberOfWheels}");
                    Console.WriteLine($"Number of seats: {castItem3.NumberOfSeats}");
                }
                else if (item is Airplane castItem4)
                {
                    Console.WriteLine("It Is an Airplane!!");
                    Console.WriteLine($"RegNr: {castItem4.RegNr}");
                    Console.WriteLine($"Color: {castItem4.Color}");
                    Console.WriteLine($"Antal hjul: {castItem4.NumberOfWheels}");
                    Console.WriteLine($"Number of engines: {castItem4.NumberOfEngines}");
                }
                else if (item is Boat castItem5)
                {
                    Console.WriteLine("It Is a Boat!!");
                    Console.WriteLine($"RegNr: {castItem5.RegNr}");
                    Console.WriteLine($"Color: {castItem5.Color}");
                    Console.WriteLine($"Antal hjul: {castItem5.NumberOfWheels}");
                    Console.WriteLine($"Length: {castItem5.Length}");
                }
                else break;
            }
        }

    }
}