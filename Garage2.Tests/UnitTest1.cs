using Microsoft.VisualStudio.TestTools.UnitTesting;
using Garage2;


namespace Garage2.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
       // public void TestMethod1()
        public void CreateGarage_WithCapacity_ReturnsCapacity()
        {
            //Arrange
            const int expected = 10;
            var garage = new Garage<Vehicle>("One", 10);

            //Act
            var actual = garage.MaxCapacity;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]        
        public void CreateCar_ReturnsCarFromGarage()
        {
            //Arrange
            Car expected = new Garage2.Car("AAA111", "Red", "4", "Diesel");
            Garage<Vehicle> g = new Garage2.Garage<Vehicle>("One", 10);
            g.AddVehicle(expected);

            //Act
            // Vehicle actual = g.GetVehicle(0);
            Vehicle actual = g[0];  //this is the same as above 
                                    //after adding in indexer on the garage 
                                    //see the last row in Garage.cs

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddCarAtFirstEmptyPlace()
        {
            //Arrange
            Car c1 = new Garage2.Car("AAA111", "Red", "4", "Diesel");
            Car c2 = new Garage2.Car("SSS222", "Blue", "4", "Diesel");
            Car c3 = new Garage2.Car("DDD333", "Yellow", "4", "Diesel");
            Car expected = new Garage2.Car("FFF444", "Silver", "4", "Diesel");
            Garage<Vehicle> g = new Garage2.Garage<Vehicle>("One", 10);
            g.AddVehicle(c1);
            g.AddVehicle(c2);
            g.AddVehicle(c3);
            g.RemoveVehicle(1);
            g.AddVehicle(expected);

            //Act
            Vehicle actual = g.GetVehicle(1);

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
