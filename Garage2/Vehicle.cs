namespace Garage2
{
    public class Vehicle
    {
        public Vehicle(string v1, string v2, string v3)
        {
            RegNr = v1;
            Color = v2;
            NumberOfWheels = v3;
        }

        public string RegNr { get; set; }
        public string Color { get; set; }
        public string NumberOfWheels { get; set; }
    }
}