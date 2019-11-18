namespace Garage2
{
    internal class MC : Vehicle
    {
        
        public string CylinderVolume { get; set; }

        public MC(string regnr, string color, string numberofwheels, string cylindervolume): base(regnr, color, numberofwheels)
        {
            
            CylinderVolume = cylindervolume;
        }
    }
}