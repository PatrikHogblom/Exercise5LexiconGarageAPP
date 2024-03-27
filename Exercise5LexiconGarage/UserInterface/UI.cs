using Exercise5LexiconGarage.Garages;
using Exercise5LexiconGarage.Helpers;
using Exercise5LexiconGarage.UserInterface;
using Exercise5LexiconGarage.Vehicles;
using Microsoft.VisualBasic.FileIO;
using System.Drawing;
using System.Net;
using System.Reflection;
using System.Security.Cryptography;

namespace Exercise5LexiconGarage
{
    public class UI : IUI
    {
        private static GarageHandler garagehandler = new GarageHandler();
        public static void DisplayMainMenu()
        {
               //to load a garage when starting application to test functions, is a pain to add everything every time
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


            bool programRun = true;
            do
            {

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
                        if(garagehandler.garageListIsNotNull() == true)
                        {
                            garagehandler.PrintGaragesStored();
                            string inputGarageName = InputHandler.GetStringInput("Enter the name of garage you want to use: ");
                            //get the index of position of tha garage name
                            int garageIndex = garagehandler.GetGarageIndexByName(inputGarageName.Trim().ToLower());
                            //2. create a submeny wheras we add vehicles to the garage
                            if (garageIndex == -1)
                            {
                                Console.WriteLine("The garage you searched for don't exist");
                            }
                            else
                            {
                                DisplaySubMenu(garageIndex);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Please create a garage first!");
                        }
                        
                        
                        break;
                    case "3":
                        programRun = false;
                        break;

                    default:
                        Console.WriteLine("Invalid Input!");
                        break;
                }
            } while (programRun);
        }

        public static void DisplaySubMenu(int indexGarage)
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
                    default:
                        Console.WriteLine("Invalid Input!");
                        break;
                }
            } while (programRun);
        }

        //todo: move createGarage object to garagehandler?
        public static void CreateGarageObject()
        {
            try
            {
                int capacity = InputHandler.GetIntegerInput("Enter capacity of parking lots in the garage: ");

                string garageName = InputHandler.GetStringInput("Enter the name of the garage:");

                string address = InputHandler.GetStringInput("Enter the address of the garage:");

                string city = InputHandler.GetStringInput("Enter the city of the garage:");

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