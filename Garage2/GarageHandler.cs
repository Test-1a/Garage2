using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Garage2
{
    internal class GarageHandler
    {
        private Garage<Vehicle> Garra /*{ get; set; }*/;
        
        public GarageHandler()
        {
        }

        internal void CreateGarage(string input11, int input12)
        {
            Garra = new Garage<Vehicle>(input11, input12);
        }

        internal List<string> GetParkQuestions(string veh)
        {
           Console.WriteLine("Fordonet: " + veh);

           List<string> parkQ = new List<string>();
           parkQ.Add("What registration number does the vehicle have?");
           parkQ.Add("What color does the vehicle have?");
           parkQ.Add("What number of wheels does the vehicle have");
           if (veh == "Car") parkQ.Add("What fueltype do you use?");
           else if (veh == "MC") parkQ.Add("What cylinder volume do you have?");
           else if (veh == "Bus") parkQ.Add("How many seats do you have?");
           else if (veh == "Airplane") parkQ.Add("How many engines do you have?");
           else if (veh == "Boat") parkQ.Add("How long is your boat?");

           return parkQ;
        }

        internal bool ParkVehicle(List<string> parkAnswers)
        {
            if (Garra.isFull) return false;
            bool success = false;

            if (parkAnswers[0] == "Car")
            {
                Car car = new Car(parkAnswers[1].ToUpper(), parkAnswers[2].ToUpper(), parkAnswers[3], parkAnswers[4].ToUpper());
                Console.WriteLine("A car has been created!");
                success = Garra.AddVehicle(car);
            }
            else if (parkAnswers[0] == "MC")
            {
                MC mc = new MC(parkAnswers[1].ToUpper(), parkAnswers[2].ToUpper(), parkAnswers[3], parkAnswers[4]);
                Console.WriteLine("An MC has been created!");
                success = Garra.AddVehicle(mc);
            }
            else if (parkAnswers[0] == "Bus")
            {
                Bus b1 = new Bus(parkAnswers[1].ToUpper(), parkAnswers[2].ToUpper(), parkAnswers[3], parkAnswers[4]);
                Console.WriteLine("A Bus has been created!");
                success = Garra.AddVehicle(b1);
            }
            else if (parkAnswers[0] == "Airplane")
            {
                Airplane a1 = new Airplane(parkAnswers[1].ToUpper(), parkAnswers[2].ToUpper(), parkAnswers[3], parkAnswers[4]);
                Console.WriteLine("An Airplane has been created!");
                success = Garra.AddVehicle(a1);
            }
            else if (parkAnswers[0] == "Boat")
            {
                Boat boat1 = new Boat(parkAnswers[1].ToUpper(), parkAnswers[2].ToUpper(), parkAnswers[3], parkAnswers[4]);
                Console.WriteLine("A Boat has been created!");
                success = Garra.AddVehicle(boat1);
            }
            printGarage();

            return success;
        }

        private void printGarage()
        {
            int index = 1;

            foreach (var item in Garra)
            {
                

                if (item != null)
                {
                    if (item is Car castItem1)
                    {

                        //PropertyInfo[] props = castItem1.GetType().GetProperties();
                        //Console.WriteLine($"{index}. {castItem1.GetType().Name}");

                        //foreach (PropertyInfo prop in props)
                        //{
                        //    Console.WriteLine($"{prop.Name}: {prop.GetValue(castItem1)}");
                        //}

                        Console.WriteLine($"{index}. {castItem1.GetType().Name}");
                        Console.WriteLine($"RegNr: {castItem1.RegNr}");
                        Console.WriteLine($"Color: {castItem1.Color}");
                        Console.WriteLine($"Antal hjul: {castItem1.NumberOfWheels}");
                        Console.WriteLine($"Fueltype: {castItem1.Fueltype}");
                    }
                    else if (item is MC castItem2)
                    {
                        Console.WriteLine($"{index}. {castItem2.GetType().Name}");
                        Console.WriteLine($"RegNr: {castItem2.RegNr}");
                        Console.WriteLine($"Color: {castItem2.Color}");
                        Console.WriteLine($"Antal hjul: {castItem2.NumberOfWheels}");
                        Console.WriteLine($"Cylinder Volume: {castItem2.CylinderVolume}");
                    }
                    else if (item is Bus castItem3)
                    {
                        Console.WriteLine($"{index}. {castItem3.GetType().Name}");
                        Console.WriteLine($"RegNr: {castItem3.RegNr}");
                        Console.WriteLine($"Color: {castItem3.Color}");
                        Console.WriteLine($"Antal hjul: {castItem3.NumberOfWheels}");
                        Console.WriteLine($"Number of seats: {castItem3.NumberOfSeats}");
                    }
                    else if (item is Airplane castItem4)
                    {
                        Console.WriteLine($"{index}. {castItem4.GetType().Name}");
                        Console.WriteLine($"RegNr: {castItem4.RegNr}");
                        Console.WriteLine($"Color: {castItem4.Color}");
                        Console.WriteLine($"Antal hjul: {castItem4.NumberOfWheels}");
                        Console.WriteLine($"Number of seats: {castItem4.NumberOfEngines}");
                    }
                    else if (item is Boat castItem5)
                    {
                        Console.WriteLine($"{index}. {castItem5.GetType().Name}");
                        Console.WriteLine($"RegNr: {castItem5.RegNr}");
                        Console.WriteLine($"Color: {castItem5.Color}");
                        Console.WriteLine($"Antal hjul: {castItem5.NumberOfWheels}");
                        Console.WriteLine($"Number of seats: {castItem5.Length}");
                    }
                }
                index++;
            }
        }

        internal bool Unpark(string regnr)
        {
            //Vehicle removeVehicle = FindVehicleByRegNr(regnr.ToUpper());
            //int removeIndex = Array.IndexOf(Garra., removeVehicle);

            Console.WriteLine("Before ToArray()");
            /*IEnumerable<int>*/ int[] x = Garra.Select((s, i) => new { i, s })
                .Where(t => t.s.RegNr == regnr)
                .Select(t => t.i).ToArray();
            
            Console.WriteLine("After ToArray()");
            //Console.WriteLine("x[0] = " + x[0]);

            foreach (var item in x)
            {
                Console.WriteLine("This is it: " + item);
            }

            try
            {
                Garra.RemoveVehicle(x[0]);
            }
            catch (IndexOutOfRangeException)
            {

                Console.WriteLine("I'm sorry, that car is not parked in the garage.");
                return false;
            }
            return true;

        }

        public Vehicle[] FindVehicleByRegNr(string regnr)
        {
            Vehicle[] vs = new Vehicle[1];
            Vehicle v = Garra.FirstOrDefault(v => v.RegNr == regnr);
            if (v is Car) Console.WriteLine("v is a car!!!!!!");
            vs[0] = v;
            return vs;
        }

        internal Vehicle[] ListAllParkedVehicles()
        {
            int numberOfVehicles = Garra.count;
            Vehicle[] vehs = new Vehicle[Garra.count];

            for (int i = 0; i < numberOfVehicles; i++)
            {
                Vehicle ve = Garra.GetVehicle(i);
                vehs[i] = ve;
            }
            return vehs;
        }

        internal /*IEnumerable<string, int>*/ void ListNumberOfEachType()
        {
            var vehiclesPerType = from vehicle in Garra
                                  group vehicle by vehicle.GetType().Name into vehicleGroup
                                   select new 
                                   {
                                       Type = vehicleGroup.Key,
                                       Count = vehicleGroup.Count(),
                                   };
            //select new Dictionary<string, int>() { { vehicleGroup.Key, vehicleGroup.Count } }

            //var test = vehiclesPerType.ToDictionary();

            vehiclesPerType.ToArray();
            //Console.WriteLine($"w1: {vehiclesPerType.ToArray()[0]}");
            //Console.WriteLine($"w2: {vehiclesPerType.ToArray()[1]}");
            //Console.WriteLine($"w3: {vehiclesPerType.ToArray()[2]}");
            //Console.WriteLine($"w4: {vehiclesPerType.ToArray()[3]}");
            //Console.WriteLine($"w5: {vehiclesPerType.ToArray()[4]}");
            //Console.WriteLine($"w6: {vehiclesPerType.ToArray()[5]}");

            foreach (var item in vehiclesPerType)
            {
                Console.WriteLine(item);
            }

            //return vehiclesPerType;
        }

        internal string ChangeMaximumCapacity(int wantedCapacity)
        {
            string answerString;

            if(wantedCapacity < Garra.count)
            {
                Garra.MaxCapacity = Garra.count;
                answerString = "New value is smaller than number of vehicles in the garage, new value is set to the number of vehicles in the garage";
            }
            else
            {
                Garra.MaxCapacity = wantedCapacity;
                answerString = "Maximum capacity set to suggested value";
            }

            return answerString;
        }

        internal /*static*/ IEnumerable<Vehicle> FindVehicle(string v, string input71, string input72)
        {
            if (v == "Color")
            {
                var vehicleQuery = Garra.Where(v => v.Color == input71.ToUpper());
                return vehicleQuery;
            }
            else if (v == "Wheels")
            {
                var vehicleQuery = Garra.Where(v => v.NumberOfWheels == input71);
                return vehicleQuery;
            }
            else if (v == "Both")
            {
                var vehicleQuery = Garra.Where(v => v.Color == input71.ToUpper() && v.NumberOfWheels == input72);
                return vehicleQuery;
            }
            else return null;
        }
    }
}