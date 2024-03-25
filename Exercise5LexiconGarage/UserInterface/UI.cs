using Exercise5LexiconGarage.Garages;
using Exercise5LexiconGarage.Vehicles;
using Microsoft.VisualBasic.FileIO;
using System.Drawing;
using System.Net;
using System.Reflection;
using System.Security.Cryptography;

namespace Exercise5LexiconGarage
{
    public class UI
    {
        private static GarageHandler garagehandler = new GarageHandler();
        public static void MainMenu()
        {
            bool programRun = true;
            do
            {

                //to load a garage when starting application to test functions
                garagehandler.addGarageToList(16, "test", "test 11", "Stockholm");
                Garage<Vehicle> currentGarage = garagehandler.GetGarageByIndex(0);
                currentGarage.addVehicle(new Car("qwe123", "röd", 4, "BMW", "2020", "gas"));
                currentGarage.addVehicle(new Car("asd123", "blå", 4, "volvo", "2010", "gas"));
                currentGarage.addVehicle(new Car("zxc123", "grå", 4, "subaru", "2010", "gas"));
                currentGarage.addVehicle(new Car("abc123", "röd", 4, "volvo", "2024", "gas"));
                currentGarage.addVehicle(new Car("fgh123", "rosa", 4, "BMW", "2020", "gas"));
                currentGarage.addVehicle(new Car("iop123", "black", 4, "volvo", "2010", "gas"));

                currentGarage.addVehicle(new AirPlane("air123", "röd", 6, "boeing", "2021", 4));
                currentGarage.addVehicle(new Bus("bus123", "röd", 8, "volvo", "1999", 24));
                currentGarage.addVehicle(new Motorcycle("mot123", "svart", 4, "honda", "2011", 24.4));
                currentGarage.addVehicle(new Boat("boa123", "röd", 4, "volvo", "2024", 15));
                currentGarage.addVehicle(new Bus("bus789", "blå", 8, "scania", "2020", 36));



                Console.WriteLine("1. Create garage and its capacity");
                Console.WriteLine("2. Choose garage to use and go to its submenu: ");
                Console.WriteLine("3. Exit the program");

                var input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        CreateGarageObject();
                        garagehandler.PrintGaragesStored();
                        break;
                    case "2":
                        //1.choose which garage you want to use
                        garagehandler.PrintGaragesStored();

                        Console.WriteLine("Enter the name of garage you want to use: ");
                        string inputGarageName = Console.ReadLine();

                        //get the index of position of tha garage name
                        int garageIndex = garagehandler.GetGarageIndexByName(inputGarageName);

                        //2. create a submeny wheras we add vehicles to the garage
                        SubMenu(garageIndex);
                        break;
                    case "3":
                        programRun = false;
                        break;
                }
            } while (programRun);
        }

        private static void SubMenu(int indexGarage)
        {
            Garage<Vehicle> currentGarage = garagehandler.GetGarageByIndex(indexGarage);
            bool programRun = true;
            do
            {
                Console.WriteLine("1. Park vehicle: ");
                Console.WriteLine("2. Remove vehicle: ");
                Console.WriteLine("3. print all parked vehicles in the garage: ");
                Console.WriteLine("4. print all parked vehicles according a type in the garage: ");
                Console.WriteLine("5. Search after a vehicle in the garage according to registernumber: ");
                Console.WriteLine("6. Search after vehicles criteras by input properties or skipping properties");
                Console.WriteLine("7. Go back to main menu");

                var input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        garagehandler.AddVehicle(currentGarage);
                        break;
                    case "2":
                        garagehandler.RemoveVehicle(currentGarage);
                        break;
                    case "3":
                        currentGarage.printVehicles();
                        break;
                    case "4":
                        garagehandler.printVehiclesByType(currentGarage);
                        break;
                    case "5":
                        garagehandler.searchVehicleByRegisterNumber(currentGarage);
                        break;
                    case "6":
                        garagehandler.searchByVehicleProperty(currentGarage);

                        break;
                    case "7":
                        programRun = false;
                        break;
                }
            } while (programRun);
        }


        //gör detta i garagehandler istället?
        public static void CreateGarageObject()
        {
            //todo: asks the user to input capacity, name, adress, city of the garage
            //before you create the object
            //have a try catch here here in case
            try
            {
                Console.WriteLine("Enter capacity of parking lots in the garage: ");
                int capacity;
                int.TryParse(Console.ReadLine(), out capacity);

                Console.WriteLine("Enter the name of the garage:");
                string garageName = Console.ReadLine();

                Console.WriteLine("Enter the address of the garage:");
                string address = Console.ReadLine();

                Console.WriteLine("Enter the city of the garage: ");
                string city = Console.ReadLine();

                //add the garage to the garageList in garageHandler 
                garagehandler.addGarageToList(capacity, garageName, address, city);

                Console.WriteLine("Garage created sucessfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong when creating garage object: " + ex.Message);
            }
        }
    }

}