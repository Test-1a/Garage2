using System;
using System.Collections;
using System.Collections.Generic;

namespace Garage2
{
    internal class Garage<T> : IEnumerable<T> where T : Vehicle 
    {
        private Vehicle[] vehicles;
        private string Name { get; set; }
        private int MaxCapacity { get; set; }
        public int count;
        public bool isFull => count >= MaxCapacity;
        

        public Garage(string input11, int input12)
        {
            Name = input11;
            MaxCapacity = input12;
            vehicles = new Vehicle[MaxCapacity];
            count = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (T item in vehicles)
            //foreach (var item in vehicles)
            {   
                //since I am using an Array, empty 
                //spaces contains null
                if (item != null)
                {
                    yield return item;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        internal bool AddVehicle(Vehicle v)
        {
            //vehicles[count] = v;
            //count++;
            //return true;

            int addIndex = Array.FindIndex(vehicles, i => i == null);
            Console.WriteLine($"AddIndex = {addIndex}");
            vehicles[addIndex] = v;
            count++;
            return true;
        }

        internal void RemoveVehicle(int v)
        {
            vehicles[v] = null;
            count--;
        }

        internal Vehicle GetVehicle(int index)
        {
            return vehicles[index];
        }
    }
}