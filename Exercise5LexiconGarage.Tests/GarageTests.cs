using Exercise5LexiconGarage.Garages;
using Exercise5LexiconGarage.Vehicles;
using Microsoft.VisualBasic.FileIO;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Security.Cryptography;

namespace Exercise5LexiconGarage.Tests
{
    public class GarageTests
    {

        //test to list parked vehciles

        [Fact]
        public void Should_PrintVehicles_WithCorrectOutput()
        {
            // Arrange
            Garage<Vehicle> garage = new Garage<Vehicle>(4, "Test Garage", "123 Street", "City");

            // Add vehicles to the garage
            garage.addVehicle(new Car("ABC123", "Red", 4, "Toyota", "2022", "Gas"));
            garage.addVehicle(new Motorcycle("XYZ456", "Blue", 2, "Honda", "2020", 24.4));
            garage.addVehicle(new AirPlane("DEF789", "Yellow", 6, "Boeing", "2018", 4));
            garage.addVehicle(new Car("GHI987", "Green", 4, "Ford", "2019", "Hybrid"));

            StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            garage.printVehicles();

            // Assert
            string expectedOutput = "------------Vehicles obj Array--------------\r\n" +
                                    "Vehicle Type: car  Register Number: ABC123  Color: red  Total Wheels: 4  Model: toyota  Year: 2022  Fuel: gas\r\n" +
                                    "Vehicle Type: motorcycle  Register Number: XYZ456  Color: blue  Total Wheels: 2  Model: honda  Year: 2020  Cylinder Volume: 24,4 cm^3\r\n" +
                                    "Vehicle Type: airplane  Register Number: DEF789  Color: yellow  Total Wheels: 6  Model: boeing  Year: 2018  Number of engines: 4\r\n" +
                                    "Vehicle Type: car  Register Number: GHI987  Color: green  Total Wheels: 4  Model: ford  Year: 2019  Fuel: hybrid\r\n" +
                                    "--------------------------------------------\r\n";
            Assert.Equal(expectedOutput, sw.ToString());
        }

        //test add and remove vehciles

        //add vehicle
        [Fact]
        public void Should_AddVehicles_WithRegNumExists()
        {
            // Arrange
            Garage<Vehicle> garage = new Garage<Vehicle>(4, "Test Garage", "123 Street", "City");
            StringWriter sw = new StringWriter();
            garage.addVehicle(new Car("ABC123", "Red", 4, "Toyota", "2022", "Gas"));

            Console.SetOut(sw);

            // Act
            garage.addVehicle(new Car("ABC123", "Blue", 4, "bmw", "2022", "hybrid"));

            // Assert
            string expectedOutput = "The registernumber ABC123 already exist, please restart process and input correct registernumber\r\n";
                                    
            Assert.Equal(expectedOutput, sw.ToString());
        }

        [Fact]
        public void Should_AddVehicles_WithNewRegNum()
        {
            // Arrange
            Garage<Vehicle> garage = new Garage<Vehicle>(4, "Test Garage", "123 Street", "City");
            StringWriter sw = new StringWriter();

            Console.SetOut(sw);

            // Act
            garage.addVehicle(new Car("ABC123", "Blue", 4, "bmw", "2022", "hybrid"));

            // Assert
            string expectedOutput = "Parked ABC123 to the garage!\r\n";

            Assert.Equal(expectedOutput, sw.ToString());
        }

        [Fact]
        public void Should_AddVehicles_WithGarageIsFull()
        {
            // Arrange
            Garage<Vehicle> garage = new Garage<Vehicle>(1, "Test Garage", "123 Street", "City");//capacity is 1 here
            StringWriter sw = new StringWriter();
            garage.addVehicle(new Car("ABC123", "Blue", 4, "bmw", "2022", "hybrid"));

            Console.SetOut(sw);

            // Act
            garage.addVehicle(new Car("QWE123", "Green", 4, "Toyota", "2019", "gas"));

            // Assert
            string expectedOutput = "Garage is full!!!\r\n";

            Assert.Equal(expectedOutput, sw.ToString());
        }

        //remove vehicle 
        [Fact]
        public void Should_RemoveVehiclesByRegisterNumber_WithCorrectMessage()
        {
            // Arrange
            Garage<Vehicle> garage = new Garage<Vehicle>(4, "Test Garage", "123 Street", "City");
            StringWriter sw = new StringWriter();
            garage.addVehicle(new Car("ABC123", "Red", 4, "Toyota", "2022", "Gas"));
            garage.addVehicle(new Motorcycle("XYZ456", "Blue", 2, "Honda", "2020", 24.4));
            garage.addVehicle(new AirPlane("DEF789", "Yellow", 6, "Boeing", "2018", 4));
            garage.addVehicle(new Car("GHI987", "Green", 4, "Ford", "2019", "Hybrid"));

            Console.SetOut(sw);

            // Act
            garage.RemoveVehicleByRegisterNumber("DEF789");

            // Assert
            string expectedOutput = "Removed DEF789 from the parking lot in the current garage.\r\n";

            Assert.Equal(expectedOutput, sw.ToString());
        }

        [Fact]
        public void Should_RemoveVehcileByRegisterNumber_CheckCapacityAfterRemove()
        {
            //Arrange 
            Garage<Vehicle> garage = new Garage<Vehicle>(4, "Test Garage", "123 Street", "City");
            //StringWriter sw = new StringWriter();
            garage.addVehicle(new Car("ABC123", "Red", 4, "Toyota", "2022", "Gas"));
            garage.addVehicle(new Motorcycle("XYZ456", "Blue", 2, "Honda", "2020", 24.4));
            garage.addVehicle(new AirPlane("DEF789", "Yellow", 6, "Boeing", "2018", 4));
            garage.addVehicle(new Car("GHI987", "Green", 4, "Ford", "2019", "Hybrid"));

            //Act
            var regNumToRemove = "DEF789";
            garage.RemoveVehicleByRegisterNumber(regNumToRemove);

            //assert
            var expectedVehciles = 3;
            var afterRemovingRegNumber = garage.GetVehicles.Length;
            Assert.Equal(expectedVehciles, afterRemovingRegNumber);
        }

        // test if capacity/count is correct when initalizing the vehciles to the garage
        [Fact]
        public void Should_AddVehcileByRegisterNumber_CheckCapacityIsEqualToAddedVehicles()
        {
            //Arrange 
            Garage<Vehicle> garage = new Garage<Vehicle>(4, "Test Garage", "123 Street", "City");
                                                                                                 

            //Act
            garage.addVehicle(new Car("ABC123", "Red", 4, "Toyota", "2022", "Gas"));
            garage.addVehicle(new Motorcycle("XYZ456", "Blue", 2, "Honda", "2020", 24.4));
            garage.addVehicle(new AirPlane("DEF789", "Yellow", 6, "Boeing", "2018", 4));
            garage.addVehicle(new Car("GHI987", "Green", 4, "Ford", "2019", "Hybrid"));


            //assert
            var expectedVehciles = 4;
            var actualVal_afterAddingVehicles = garage.GetVehicles.Length;
            Assert.Equal(expectedVehciles, actualVal_afterAddingVehicles);
        }

        //test possibility to find a vehicle using registernumber(should work with ABC123, Abc123, AbC123)
        [Fact]
        public void Should_SearchVehicleByRegisterNumber_ReturnTrue()
        {
            //Arrange 
            Garage<Vehicle> garage = new Garage<Vehicle>(4, "Test Garage", "123 Street", "City");
                                                                                                 

            //Act
            garage.addVehicle(new Car("ABC123", "Red", 4, "Toyota", "2022", "Gas"));
            garage.addVehicle(new Motorcycle("XYZ456", "Blue", 2, "Honda", "2020", 24.4));
            garage.addVehicle(new AirPlane("DEF789", "Yellow", 6, "Boeing", "2018", 4));
            garage.addVehicle(new Car("GHI987", "Green", 4, "Ford", "2019", "Hybrid"));


            //assert
            var expected = true;
            var actual = garage.searchVehicleByRegisterNumber("GHI987");
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Should_SearchVehicleByRegisterNumber_ReturnFalse()
        {
            //Arrange 
            Garage<Vehicle> garage = new Garage<Vehicle>(4, "Test Garage", "123 Street", "City");
                                                                                                

            //Act
            garage.addVehicle(new Car("ABC123", "Red", 4, "Toyota", "2022", "Gas"));
            garage.addVehicle(new Motorcycle("XYZ456", "Blue", 2, "Honda", "2020", 24.4));
            garage.addVehicle(new AirPlane("DEF789", "Yellow", 6, "Boeing", "2018", 4));
            garage.addVehicle(new Car("GHI987", "Green", 4, "Ford", "2019", "Hybrid"));


            //assert
            var expected = false;
            var actual = garage.searchVehicleByRegisterNumber("ABC779");
            Assert.Equal(expected, actual);
        }

        // Test possiblity to search a vehicle by a critera
        [Fact]
        public void Should_SearchAndListVehicleBySpecificType_PrintMessage()
        {
            // Arrange
            Garage<Vehicle> garage = new Garage<Vehicle>(4, "Test Garage", "123 Street", "City");

            // Add vehicles to the garage
            garage.addVehicle(new Car("ABC123", "Red", 4, "Toyota", "2022", "Gas"));
            garage.addVehicle(new Motorcycle("XYZ456", "Blue", 2, "Honda", "2020", 24.4));
            garage.addVehicle(new AirPlane("DEF789", "Yellow", 6, "Boeing", "2018", 4));
            garage.addVehicle(new Car("GHI987", "Green", 4, "Ford", "2019", "Hybrid"));

            StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            garage.searchVehiclesForAType("Car");

            // Assert
            string expectedOutput = "Vehciles of type Car that exists in current garage are: \r\n" +
                                    "----------------------------------------------\r\n" +
                                    "Vehicle Type: car  Register Number: ABC123  Color: red  Total Wheels: 4  Model: toyota  Year: 2022  Fuel: gas\r\n" +
                                    "Vehicle Type: car  Register Number: GHI987  Color: green  Total Wheels: 4  Model: ford  Year: 2019  Fuel: hybrid\r\n" +
                                    "-----------------------------------------------\r\n";
            Assert.Equal(expectedOutput, sw.ToString());
        }

        // test filter types
        [Fact]
        public void Should_FilterVehicles_ByVehcileType()
        {
            // Arrange
            Garage<Vehicle> garage = new Garage<Vehicle>(4, "Test Garage", "123 Street", "City");

            // Add vehicles to the garage
            garage.addVehicle(new Car("ABC123", "Red", 4, "Toyota", "2022", "Gas"));
            garage.addVehicle(new Motorcycle("XYZ456", "Blue", 2, "Honda", "2020", 24.4));
            garage.addVehicle(new AirPlane("DEF789", "Yellow", 6, "Boeing", "2018", 4));
            garage.addVehicle(new Car("GHI987", "Green", 4, "Ford", "2019", "Hybrid"));

            string selectedType = "car";

            // Act
            var filteredVehicles = garage.FilterByVehicleType(selectedType, garage.GetVehicles);

            // Assert
            Assert.Equal(2, filteredVehicles.Length); // Expecting 2 cars in the garage
            foreach (var vehicle in filteredVehicles)
            {
                Assert.IsType<Car>(vehicle); // Ensure all filtered vehicles are of type Car
            }
        }

        [Fact]
        public void Should_FilterVehicles_ByVehicleColor()
        {
            // Arrange
            Garage<Vehicle> garage = new Garage<Vehicle>(4, "Test Garage", "123 Street", "City");

            // Add vehicles to the garage
            garage.addVehicle(new Car("ABC123", "Red", 4, "Toyota", "2022", "Gas"));
            garage.addVehicle(new Motorcycle("XYZ456", "Blue", 2, "Honda", "2020", 24.4));
            garage.addVehicle(new AirPlane("DEF789", "Yellow", 6, "Boeing", "2018", 4));
            garage.addVehicle(new Car("GHI987", "Green", 4, "Ford", "2019", "Hybrid"));

            string selectedColor = "Red";

            // Act
            var filteredVehicles = garage.FilterByVehicleColor(selectedColor.ToLower(), garage.GetVehicles);

            // Assert
            Assert.Single(filteredVehicles); // Expecting 2 vehicles with the color "Red"
            foreach (var vehicle in filteredVehicles)
            {
                Assert.Equal(selectedColor.ToLower(), vehicle.Color.ToLower()); // Ensure all filtered vehicles have the correct color
            }
        }
        [Fact]
        public void Should_FilterVehicles_ByVehicleRegNum()
        {
            // Arrange
            Garage<Vehicle> garage = new Garage<Vehicle>(4, "Test Garage", "123 Street", "City");

            // Add vehicles to the garage
            garage.addVehicle(new Car("ABC123", "Red", 4, "Toyota", "2022", "Gas"));
            garage.addVehicle(new Motorcycle("XYZ456", "Blue", 2, "Honda", "2020", 24.4));
            garage.addVehicle(new AirPlane("DEF789", "Yellow", 6, "Boeing", "2018", 4));
            garage.addVehicle(new Car("GHI987", "Green", 4, "Ford", "2019", "Hybrid"));

            string selectedregNum = "XYZ456";

            // Act
            var filteredVehicles = garage.FilterByVehicleRegNum(selectedregNum, garage.GetVehicles);

            // Assert
            Assert.Single(filteredVehicles); // Expecting 2 vehicles with the color "Red"
            foreach (var vehicle in filteredVehicles)
            {
                Assert.Equal(selectedregNum.ToLower(), vehicle.RegisterNumber.ToLower()); // Ensure all filtered vehicles have the correct color
            }
        }

        [Fact]
        public void Should_FilterVehicles_ByNumWheels()
        {
            // Arrange
            Garage<Vehicle> garage = new Garage<Vehicle>(5, "Test Garage", "123 Street", "City");

            // Add vehicles to the garage
            garage.addVehicle(new Car("ABC123", "Red", 4, "Toyota", "2022", "Gas"));
            garage.addVehicle(new Motorcycle("XYZ456", "Blue", 2, "Honda", "2020", 24.4));
            garage.addVehicle(new AirPlane("DEF789", "Yellow", 6, "Boeing", "2022", 4));
            garage.addVehicle(new Car("GHI987", "Green", 4, "Ford", "2019", "Hybrid"));
            garage.addVehicle(new Car("´BMN987", "Blue", 4, "BMW", "2022", "Gas"));

            int selectedByNumWheels = 4;

            // Act
            var filteredVehicles = garage.FilterByNumWheels(selectedByNumWheels, garage.GetVehicles);

            // Assert
            Assert.Equal(3,filteredVehicles.Length); // Expecting 3 vehicles with 4 wheels
            foreach (var vehicle in filteredVehicles)
            {
                Assert.Equal(selectedByNumWheels, vehicle.TotWheels); // Ensure all filtered vehicles have the correct wheels
            }
        }

        [Fact]
        public void Should_FilterVehicles_ByModel()
        {
            // Arrange
            Garage<Vehicle> garage = new Garage<Vehicle>(4, "Test Garage", "123 Street", "City");

            // Add vehicles to the garage with different models
            garage.addVehicle(new Car("ABC123", "Red", 4, "Toyota", "2022", "Gas")); // Toyota
            garage.addVehicle(new Motorcycle("XYZ456", "Blue", 2, "Honda", "2020", 24.4)); // Honda
            garage.addVehicle(new AirPlane("DEF789", "Yellow", 6, "Boeing", "2018", 4)); // Boeing
            garage.addVehicle(new Car("GHI987", "Green", 4, "Ford", "2019", "Hybrid")); // Ford

            string selectedModel = "Toyota";

            // Act
            var filteredVehicles = garage.FilterByVehicleModel(selectedModel, garage.GetVehicles);

            // Assert
            Assert.Single(filteredVehicles); // Expecting 1 vehicle with the model "Toyota"
            foreach (var vehicle in filteredVehicles)
            {
                Assert.Equal(selectedModel.ToLower(), vehicle.Model.ToLower()); // Ensure all filtered vehicles have the correct model
            }
        }

        [Fact]
        public void Should_FilterVehicles_ByYear()
        {
            // Arrange
            Garage<Vehicle> garage = new Garage<Vehicle>(4, "Test Garage", "123 Street", "City");

            // Add vehicles to the garage with different years
            garage.addVehicle(new Car("ABC123", "Red", 4, "Toyota", "2022", "Gas")); // 2022
            garage.addVehicle(new Motorcycle("XYZ456", "Blue", 2, "Honda", "2022", 24.4)); // 2020
            garage.addVehicle(new AirPlane("DEF789", "Yellow", 6, "Boeing", "2018", 4)); // 2018
            garage.addVehicle(new Car("GHI987", "Green", 4, "Ford", "2022", "Hybrid")); // 2019

            string selectedYear = "2022";

            // Act
            var filteredVehicles = garage.FilterByVehicleYear(selectedYear, garage.GetVehicles);

            // Assert
            Assert.Equal(3, filteredVehicles.Length); // Expecting 3 vehicle with the year "2022"
            foreach (var vehicle in filteredVehicles)
            {
                Assert.Equal(selectedYear.ToLower(), vehicle.Year.ToLower()); // Ensure all filtered vehicles have the correct year
            }
        }

        //lastly test the emulator
        [Fact]
        public void Should_IterateThroughVehicles()
        {
            // Arrange
            Garage<Vehicle> garage = new Garage<Vehicle>(4, "Test Garage", "123 Street", "City");

            // Add vehicles to the garage
            garage.addVehicle(new Car("ABC123", "Red", 4, "Toyota", "2022", "Gas"));
            garage.addVehicle(new Motorcycle("XYZ456", "Blue", 2, "Honda", "2020", 24.4));
            garage.addVehicle(new AirPlane("DEF789", "Yellow", 6, "Boeing", "2018", 4));
            garage.addVehicle(new Car("GHI987", "Green", 4, "Ford", "2019", "Hybrid"));

            // Act
            var enumerator = garage.GetEnumerator();
            List<Vehicle> vehicles = new List<Vehicle>();

            while (enumerator.MoveNext())
            {
                vehicles.Add(enumerator.Current);
            }

            // Assert
            Assert.Equal(4, vehicles.Count); // Ensure all vehicles are iterated
                                             // Add additional assertions as needed to verify the correct vehicles are returned
        }

    }
}