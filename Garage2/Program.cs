using System;

namespace Garage2
{
    class Program
    {
        static void Main(string[] args)
        {
            //1. When starting, must only be able to create a Garage
            //2. Names of variables that describes better (not "input71")
            //3. Remove being able to change the MaxCapacity (menuchoise 6)
            //4. Bryt ut fler metoder så menyn blir enklare att följa
            //5. Ska INTE kunna lägga in 2 fordon med samma regnr!
            //6. 

            UI theUI = new UI();
            theUI.Run();
        }
    }
}
