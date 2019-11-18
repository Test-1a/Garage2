namespace Garage2
{
    internal class Bus : Vehicle
    {
        
        public string NumberOfSeats { get; set; }

        public Bus(string regnr, string color, string numberofwheels, string numberofseats) : base(regnr, color, numberofwheels)
        {

            NumberOfSeats = numberofseats;
        }
    }
}