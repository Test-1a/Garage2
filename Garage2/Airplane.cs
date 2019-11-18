namespace Garage2
{
    internal class Airplane : Vehicle
    {

        public string NumberOfEngines { get; set; }
        public Airplane(string RegNr, string Color, string NumberOfWheels, string numberofengines) : base(RegNr, Color, NumberOfWheels)
        {
            NumberOfEngines = numberofengines;
        }
    }
}