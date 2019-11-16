using System;

namespace Garage2
{
    internal class GarageHandler
    {
        private Garage<Vehicle> Garra { get; set; }
        public GarageHandler()
        {
        }

        internal void CreateGarage(string input11, int input12)
        {
            Garra = new Garage<Vehicle>(input11, input12);
        }
    }
}