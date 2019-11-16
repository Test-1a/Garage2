using System.Collections;
using System.Collections.Generic;

namespace Garage2
{
    internal class Garage<T> : IEnumerable<T> where T : Vehicle 
    {
        private Vehicle[] vehicles;
        private string Name { get; set; }
        private int MaxCapacity { get; set; }

        public Garage(string input11, int input12)
        {
            Name = input11;
            MaxCapacity = input12;
            vehicles = new Vehicle[MaxCapacity];
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (T item in vehicles)
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
    }
}