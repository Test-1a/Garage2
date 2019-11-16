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
                    
                }
                index++;
            }
        }

        internal void Unpark(string regnr)
        {
            //Vehicle removeVehicle = FindVehicleByRegNr(regnr.ToUpper());
            //int removeIndex = Array.IndexOf(Garra., removeVehicle);

            /*IEnumerable<int>*/ int[] x = Garra.Select((s, i) => new { i, s })
                .Where(t => t.s.RegNr == regnr)
                .Select(t => t.i).ToArray();

            foreach (var item in x)
            {
                Console.WriteLine("This is it: " + item);
            }

            Garra.RemoveVehicle(x[0]);

        }

        private Vehicle FindVehicleByRegNr(string regnr)
        {
            Vehicle v = Garra.FirstOrDefault(v => v.RegNr == regnr);
            return v;
        }
    }
}