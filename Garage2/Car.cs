namespace Garage2
{
    public class Car : Vehicle
    {

        public string Fueltype { get; set; }

        public Car(string v1, string v2, string v3, string fuel) :base(v1, v2, v3)
        {
           
            Fueltype = fuel;
        }
    }
}