namespace Garage2
{
    internal class Boat : Vehicle
    {
        public string Length { get; set; }

        public Boat(string regnr, string color, string numberofwheels, string length) : base(regnr, color, numberofwheels)
        {
            Length = length;
        }
    }
}