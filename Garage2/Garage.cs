using System;
using System.Collections;
using System.Collections.Generic;

namespace Garage2
{
    public class Garage<T> : IEnumerable<T> where T : Vehicle 
    {
        private T[] vehicles;
        private string Name { get; set; }
        public int MaxCapacity { get; set; }
        public int Count;
        public bool isFull => Count >= MaxCapacity;
        

        public Garage(string input11, int input12)
        {
            Name = input11;
            MaxCapacity = input12;
            vehicles = new T[MaxCapacity];
            Count = 0;
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

        //internal bool AddVehicle(Vehicle v)
        public bool AddVehicle(T v)
        {
            //vehicles[count] = v;
            //count++;
            //return true;

            int addIndex = Array.FindIndex(vehicles, i => i == null);
            Console.WriteLine($"AddIndex = {addIndex}");
            vehicles[addIndex] = v;
            Count++;
            return true;
        }

        //internal void RemoveVehicle(int v)
        public void RemoveVehicle(int v)
        {
            vehicles[v] = null;
            Count--;
        }

        //internal Vehicle GetVehicle(int index)
        public T GetVehicle(int index)
        {
            return vehicles[index];
        }

        //this means the garage
        //Now you can get a vihecles by just 
        //indexing directly on the garage
        public T this[int index] => vehicles[index];
    }
}